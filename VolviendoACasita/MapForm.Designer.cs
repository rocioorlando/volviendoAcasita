using GMap.NET.WindowsForms;
using GMap.NET;

namespace VolviendoACasita.UI
{
    partial class MapForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>



        private void InitializeComponent()
        {
            this.SuspendLayout();

            // 
            // gMapControl
            // 
            this.gMapControl.Bearing = 0F;
            this.gMapControl.CanDragMap = true;
            this.gMapControl.EmptyTileColor = Color.Navy;
            this.gMapControl.GrayScaleMode = false;
            this.gMapControl.HelperLineOption = HelperLineOptions.DontShow;
            this.gMapControl.LevelsKeepInMemmory = 5;
            this.gMapControl.Location = new Point(12, 12);
            this.gMapControl.MarkersEnabled = true;
            this.gMapControl.MaxZoom = 18;
            this.gMapControl.MinZoom = 2;
            this.gMapControl.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
            this.gMapControl.Name = "gMapControl";
            this.gMapControl.NegativeMode = false;
            this.gMapControl.PolygonsEnabled = true;
            this.gMapControl.RetryLoadTile = 0;
            this.gMapControl.RoutesEnabled = true;
            this.gMapControl.ScaleMode = ScaleModes.Integer;
            this.gMapControl.SelectedAreaFillColor = Color.FromArgb(33, 65, 105, 225);
            this.gMapControl.ShowTileGridLines = false;
            this.gMapControl.Size = new Size(776, 426);
            this.gMapControl.TabIndex = 0;
            this.gMapControl.Zoom = 10;

            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.gMapControl);
            this.Name = "MapForm";
            this.Text = "MapForm";
            this.Load += new EventHandler(MapForm_Load);
            this.ResumeLayout(false);
        }

        #endregion
    }
}