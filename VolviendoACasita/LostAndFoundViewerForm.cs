using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VolviendoACasita.Business.Interfaces;
using VolviendoACasita.Domain.Dto;
using VolviendoACasita.Domain.Entity;

namespace VolviendoACasita.UI
{
    public partial class LostAndFoundViewerForm : Form
    {
        private readonly ILostFoundFormService lostFoundFormService;
        private int id;
        private static LostAndFoundViewerForm? lostAndFoundViewerForm;
        private int currentImageIndex = 0;

        public LostAndFoundViewerForm(int id, ILostFoundFormService lostFoundFormService)
        {
            this.id = id;
            this.lostFoundFormService = lostFoundFormService;
            InitializeComponent();

            LoadFormData();
        }

        private void LoadFormData()
        {
            // Cargar datos del formulario desde el servicio
            LostFoundFormDto form = GetForm(id);

            // Mostrar datos de la mascota
            PetDto pet = form.Pet;
            lblName.Text = $"Nombre: {pet.Name}";
            lblAge.Text = $"Edad: {pet.Age}";
            lblWeight.Text = $"Peso: {pet.Weight}";
            lblColor.Text = $"Color: {pet.Color}";
            lblBreed.Text = $"Raza: {pet.Breed}";
            lblIsCastrated.Text = $"Castrado: {(pet.IsCastrated == true ? "Sí" : "No")}";
            lblIsOnMedication.Text = $"Necesita medicación: {(pet.IsOnMedication == true ? "Sí" : "No")}";
            lblRespondsTo.Text = $"Responde a: {pet.RespondsTo}";
            lblIsVaccinated.Text = $"Vacunado: {(pet.IsVaccinated == true ? "Sí" : "No")}";
            lblMedicationNotes.Text = $"Notas de medicación: {pet.MedicationNotes}";
            lblIsOwner.Text = $"Dueño: {(pet.IsOwner ? "Sí" : "No")}";
            lblHasVifVilef.Text = $"Tiene VIF/ViLEF: {(pet.HasVifVilef == true? "Sí" : "No")}";
            lblHasTag.Text = $"Tiene placa: {(pet.HasTag == true ? "Sí" : "No")}";

            // Mostrar datos del formulario
            lblObservation.Text = $"Observación: {form.Observation}";
            lblContactPhone.Text = $"Teléfono de contacto: {form.ContactPhone}";
            lblFormCreationDate.Text = $"Fecha de creación del formulario: {form.CreatedDate}";
            lblFormStatus.Text = $"Estado del formulario: {form.FormStatusId}";
            lblPetLostFoundDate.Text = $"Fecha de pérdida/encontrada: {form.PetLostFoundDate}";

            // Mostrar ubicación
            var location = form.LostFoundLocation;
            lblLocationDescription.Text = $"Ubicación: {location}";

            // Cargar imágenes de la mascota en el carrusel
            LoadCarouselImages(form.Pet);
        }

        private void LoadCarouselImages(PetDto pet)
        {
            // Cargar imágenes de la mascota directamente de `pet.Archives`
            List<ArchiveDto> petArchives = pet.Archive;

            // Vaciar el panel antes de agregar nuevas imágenes
            picCarouselPanel.Controls.Clear();

            // Cargar las imágenes en el panel
            foreach (ArchiveDto archive in petArchives)
            {
                PictureBox pic = new PictureBox
                {
                    ImageLocation = archive.Url,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new System.Drawing.Size(250, 250) // Ajusta el tamaño según tus necesidades
                };

                // Añadir la imagen al panel
                picCarouselPanel.Controls.Add(pic);
            }

            // Iniciar el temporizador para el carrusel
            carouselTimer.Start();
        }

        private LostFoundFormDto GetForm(int id)
        {
            return lostFoundFormService.Get(id);
        }

        private void CarouselTimer_Tick(object sender, EventArgs e)
        {
            // Cambiar la imagen actual en el carrusel
            if (picCarouselPanel.Controls.Count > 0)
            {
                // Avanzar al siguiente PictureBox
                currentImageIndex = (currentImageIndex + 1) % picCarouselPanel.Controls.Count;

                // Mover el panel para mostrar la imagen actual
                picCarouselPanel.ScrollControlIntoView(picCarouselPanel.Controls[currentImageIndex]);
            }
        }

        public static LostAndFoundViewerForm CreateLostAndFoundViewerForm(int id, ILostFoundFormService lostFoundFormService)
        {

            if (lostAndFoundViewerForm == null || lostAndFoundViewerForm.IsDisposed)
            {
                lostAndFoundViewerForm = new LostAndFoundViewerForm(id, lostFoundFormService);
            }
            return lostAndFoundViewerForm;
        }
    }
}
