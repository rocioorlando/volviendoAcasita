namespace VolviendoACasita.UI
{
    partial class LostAndFoundViewerForm
    {
        private System.ComponentModel.IContainer components = null;

        // Definición de los controles
        private FlowLayoutPanel picCarouselPanel;
        private System.Windows.Forms.Timer carouselTimer;

        // Definición de etiquetas para los datos de la mascota
        private Label lblName;
        private Label lblAge;
        private Label lblWeight;
        private Label lblColor;
        private Label lblBreed;
        private Label lblIsCastrated;
        private Label lblIsOnMedication;
        private Label lblRespondsTo;
        private Label lblIsVaccinated;
        private Label lblMedicationNotes;
        private Label lblIsOwner;
        private Label lblHasVifVilef;
        private Label lblHasTag;

        // Definición de etiquetas para los datos del formulario
        private Label lblObservation;
        private Label lblContactPhone;
        private Label lblFormCreationDate;
        private Label lblFormStatus;
        private Label lblPetLostFoundDate;
        private Label lblLocationDescription;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "LostAndFoundViewerForm";

            // Inicialización de los controles de etiquetas
            InitializeLabels();

            // Inicialización del carrusel de fotos
            InitializeCarousel();
        }

        private void InitializeLabels()
        {
            // Inicialización de etiquetas para datos de la mascota
            lblName = new Label { Location = new Point(10, 10), Width = 250 };
            lblAge = new Label { Location = new Point(10, 30), Width = 250 };
            lblWeight = new Label { Location = new Point(10, 50), Width = 250 };
            lblColor = new Label { Location = new Point(10, 70), Width = 250 };
            lblBreed = new Label { Location = new Point(10, 90), Width = 250 };
            lblIsCastrated = new Label { Location = new Point(10, 110), Width = 250 };
            lblIsOnMedication = new Label { Location = new Point(10, 130), Width = 250 };
            lblRespondsTo = new Label { Location = new Point(10, 150), Width = 250 };
            lblIsVaccinated = new Label { Location = new Point(10, 170), Width = 250 };
            lblMedicationNotes = new Label { Location = new Point(10, 190), Width = 250 };
            lblIsOwner = new Label { Location = new Point(10, 210), Width = 250 };
            lblHasVifVilef = new Label { Location = new Point(10, 230), Width = 250 };
            lblHasTag = new Label { Location = new Point(10, 250), Width = 250 };

            // Inicialización de etiquetas para datos del formulario
            lblObservation = new Label { Location = new Point(10, 300), Width = 250 };
            lblContactPhone = new Label { Location = new Point(10, 320), Width = 250 };
            lblFormCreationDate = new Label { Location = new Point(10, 340), Width = 250 };
            lblFormStatus = new Label { Location = new Point(10, 360), Width = 250 };
            lblPetLostFoundDate = new Label { Location = new Point(10, 380), Width = 250 };
            lblLocationDescription = new Label { Location = new Point(10, 400), Width = 250 };

            // Añadir las etiquetas al formulario
            this.Controls.AddRange(new Control[]
            {
                lblName,
                lblAge,
                lblWeight,
                lblColor,
                lblBreed,
                lblIsCastrated,
                lblIsOnMedication,
                lblRespondsTo,
                lblIsVaccinated,
                lblMedicationNotes,
                lblIsOwner,
                lblHasVifVilef,
                lblHasTag,
                lblObservation,
                lblContactPhone,
                lblFormCreationDate,
                lblFormStatus,
                lblPetLostFoundDate,
                lblLocationDescription
            });
        }

        private void InitializeCarousel()
        {
            // Inicialización del panel para el carrusel de fotos
            picCarouselPanel = new FlowLayoutPanel
            {
                Location = new Point(500, 10),
                Size = new System.Drawing.Size(280, 280),
                AutoScroll = true,
                FlowDirection = FlowDirection.LeftToRight
            };

            // Inicialización del temporizador para el carrusel de fotos
            carouselTimer = new System.Windows.Forms.Timer
            {
                Interval = 3000 // Intervalo de 3 segundos para cambiar las imágenes
            };
            carouselTimer.Tick += CarouselTimer_Tick;

            // Añadir el panel de carrusel al formulario
            this.Controls.Add(picCarouselPanel);
        }

        #endregion
    }
}
