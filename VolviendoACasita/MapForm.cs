using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using VolviendoACasita.Business.Interfaces;
using VolviendoACasita.Domain.Dto;

namespace VolviendoACasita.UI
{
    public partial class MapForm : Form
    {
        private readonly ILostFoundFormService lostFoundFormService;
        private readonly GMapControl gMapControl;

        public MapForm(ILostFoundFormService lostFoundFormService, GMapControl gMapControl)
        {
            this.lostFoundFormService = lostFoundFormService;
            this.gMapControl = gMapControl;
            
            InitializeComponent();
            InitializeMap();
        }

        private void InitializeMap()
        {         
            gMapControl.OnMarkerClick += GMapControl_OnMarkerClick;
        }

        private void GMapControl_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (item != null && item.Tag is LostFoundFormDto form)
            {
                gMapControl.Position = new PointLatLng(form.LostFoundLocation.Latitude, form.LostFoundLocation.Longitude);
                gMapControl.Zoom = 15; 
            }
        }
        private void LoadMapPoints(List<LostFoundFormDto> forms)
        {
            GMapOverlay markers = new GMapOverlay("markers");
            markers.Markers.Clear(); // Limpiar los marcadores anteriores

            foreach (var form in forms)
            {
                var position = new PointLatLng(form.LostFoundLocation.Latitude, form.LostFoundLocation.Longitude);
                GMarkerGoogleType markerType = form.FormStatusId == 1 ? GMarkerGoogleType.red_dot : GMarkerGoogleType.blue_dot;

                var marker = new GMarkerGoogle(position, markerType)
                {
                    Tag = form
                };

                marker.ToolTipText = $"{form.Pet.Name}";
                markers.Markers.Add(marker);
            }

            gMapControl.Overlays.Clear(); // Limpiar overlays anteriores
            gMapControl.Overlays.Add(markers);
        }


        private void MapForm_Load(object sender, EventArgs e)
        {
            var forms = lostFoundFormService.GetAllForm();
            LoadMapPoints(forms);
        }
    }
}
