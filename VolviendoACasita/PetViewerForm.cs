using GMap.NET.WindowsForms;
using VolviendoACasita.Business.Interfaces;
using VolviendoACasita.Domain.Dto;

namespace VolviendoACasita.UI
{
    public partial class PetViewerForm : Form
    {
        private List<PetDto> pets;
        private readonly IUserService userService;
        private readonly IBreedService breedService;
        private readonly ISpeciesService speciesService;
        private static PetRegisterForm? petRegisterForm;
        private readonly IPetService petService;
        private readonly IProvinceService provinceService;
        private readonly ILocationService locationService;
        private readonly IEmailService emailService;
        private readonly IAuthenticationService authenticationService;
        private readonly ILostFoundFormService lostFoundFormService;
        private LostAndFoundForm lostAndFoundForm;
        private UserDto user;
        private bool isSave;
        private GMapControl gMapControl;

        public PetViewerForm(List<PetDto> pets, LostAndFoundForm lostAndFoundForm, bool isSave, UserDto user, IUserService userService, ILocationService locationService, IProvinceService provinceService, IEmailService emailService,
            IAuthenticationService authenticationService, ILostFoundFormService lostFoundFormService, IBreedService breedService, ISpeciesService speciesService, IPetService petService, GMapControl gMapControl)
        {

            this.pets = pets;
            this.isSave = isSave;
            this.user = user;
            this.userService = userService;
            this.lostAndFoundForm = lostAndFoundForm;
            this.locationService = locationService;
            this.provinceService = provinceService;
            this.emailService = emailService;
            this.authenticationService = authenticationService;
            this.lostFoundFormService = lostFoundFormService;
            this.breedService = breedService;
            this.speciesService = speciesService;
            this.petService = petService;
            this.gMapControl = gMapControl;
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Limpiar cualquier control existente en flowLayoutPanelPets
            flowLayoutPanelPets.Controls.Clear();

            // Iterar sobre la lista de mascotas y crear controles para cada una
            foreach (var pet in pets)
            {
                // Crear un panel para cada mascota
                Panel petItemPanel = new Panel
                {
                    Size = new Size(300, 500),
                    Margin = new Padding(10),
                    BorderStyle = BorderStyle.FixedSingle
                };


                string imageUrl = pet.Archive.Count > 0 ? pet.Archive[0].Url : "";

                // Crear y configurar PictureBox para la imagen de la mascota
                PictureBox petPictureBox = new PictureBox
                {
                    Size = new Size(250, 250), // Tamaño más grande para mejor visualización
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    ImageLocation = imageUrl,
                    Visible = true
                };
                // Centrar el PictureBox en el panel
                petPictureBox.Location = new Point(
                    (petItemPanel.Width - petPictureBox.Width) / 2,
                    0 // Posición en la parte superior del Panel
                );

                petItemPanel.Controls.Add(petPictureBox);

                // Crear y configurar etiquetas para la información de la mascota
                Label petNameLabel = new Label
                {
                    Text = $"Nombre: {pet.Name}",
                    Location = new Point(25, 270),
                    AutoSize = true
                };
                petItemPanel.Controls.Add(petNameLabel);

                Label petSpeciesLabel = new Label
                {
                    Text = $"Especies: {(pet.Breed != null ? pet.Breed.Species.Description : "Unknown")}",
                    Location = new Point(25, 300),
                    AutoSize = true
                };
                petItemPanel.Controls.Add(petSpeciesLabel);

                Label petBreedLabel = new Label
                {
                    Text = $"Raza: {(pet.Breed != null ? pet.Breed.Description : "Unknown")}",
                    Location = new Point(25, 330),
                    AutoSize = true
                };
                petItemPanel.Controls.Add(petBreedLabel);

                Label petIsOwner = new Label
                {
                    Text = $"Es Dueño: {(pet.IsOwner == true ? "Si" : "No")}",
                    Location = new Point(25, 360),
                    AutoSize = true
                };
                petItemPanel.Controls.Add(petIsOwner);

                // Crear y configurar botón de editar
                Button editButton = new Button
                {
                    Text = "Edit",
                    Location = new Point(25, 380),
                    Size = new Size(250, 30)
                };
                editButton.Tag = pet.Id;
                editButton.Click += EditButton_Click;
                petItemPanel.Controls.Add(editButton);

                // Agregar el panel de mascota al FlowLayoutPanel
                flowLayoutPanelPets.Controls.Add(petItemPanel);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            Button editButton = sender as Button;
            if (editButton != null)
            {
                int petId = (int)editButton.Tag;
                // Lógica para editar la mascota con el ID petId
                EditPet(petId);
            }
        }

        private void EditPet(int petId)
        {

            bool isSave = true;
            var petRegister = new PetRegisterForm(petId, lostAndFoundForm, isSave, user, userService, locationService, provinceService, emailService, authenticationService, lostFoundFormService, breedService, speciesService, petService, gMapControl);
            petRegister.Show();
        }
    }
}
