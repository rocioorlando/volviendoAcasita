using System;
using System.Drawing;
using System.Windows.Forms;
using VolviendoACasita.Domain.Dto;
using System.Collections.Generic;
using VolviendoACasita.Business.Interfaces;
using GMap.NET.WindowsForms;

namespace VolviendoACasita.UI
{
    public partial class ProfileViewerForm : Form
    {
        private UserDto user;
        private PictureBox profilePictureBox;
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
        private bool isSave;
        private LostAndFoundForm lostAndFoundForm;
        private GMapControl gMapControl;
        private static ProfileViewerForm? profileViewerForm;

        public ProfileViewerForm(UserDto user, List<PetDto> pets, LostAndFoundForm lostAndFoundForm, bool isSave, IUserService userService, ILocationService locationService, IProvinceService provinceService, IEmailService emailService,
            IAuthenticationService authenticationService, ILostFoundFormService lostFoundFormService, IBreedService breedService, ISpeciesService speciesService, IPetService petService, GMapControl gMapControl)
        {
            this.user = user;
            this.pets = pets;
            this.pets = pets;
            this.isSave = isSave;
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

        }

        private void ProfileViewerForm_Load(object sender, EventArgs e)
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Crear el panel para organizar los controles
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill, // Se extiende para llenar todo el formulario
                Padding = new Padding(20) // Añadir un relleno para espaciar los controles
            };

            // Crear la PictureBox para mostrar la imagen del usuario
            profilePictureBox = new PictureBox
            {
                Size = new Size(150, 150),
                Location = new Point(20, 20),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            profilePictureBox.ImageLocation = "https://img.freepik.com/vector-premium/icono-perfil-usuario-estilo-plano-ilustracion-vector-avatar-miembro-sobre-fondo-aislado-concepto-negocio-signo-permiso-humano_157943-15752.jpg";
            panel.Controls.Add(profilePictureBox);

            // Crear un panel para los datos del usuario
            Panel userDataPanel = new Panel
            {
                Location = new Point(200, 20),
                Width = 400, // Ancho del panel de datos del usuario
                AutoSize = true // Ajustar automáticamente la altura del panel según el contenido
            };

            // Organizar los datos del usuario en dos columnas
            int verticalPosition = 0;
            int firstColumnX = 0;
            int secondColumnX = userDataPanel.Width / 2;
            int labelWidth = userDataPanel.Width / 2 - 40; // Ancho de las etiquetas
            int labelHeight = 30; // Altura de las etiquetas

            // Agregar todas las etiquetas para mostrar los datos del usuario
            AddUserDataLabel(userDataPanel, "User Name:", user.UserName, firstColumnX, ref verticalPosition, labelWidth, labelHeight);
            AddUserDataLabel(userDataPanel, "Name:", user.Name, firstColumnX, ref verticalPosition, labelWidth, labelHeight);
            AddUserDataLabel(userDataPanel, "Last Name:", user.LastName, firstColumnX, ref verticalPosition, labelWidth, labelHeight);
            AddUserDataLabel(userDataPanel, "DNI:", user.Dni, firstColumnX, ref verticalPosition, labelWidth, labelHeight);
            AddUserDataLabel(userDataPanel, "Email:", user.Email, firstColumnX, ref verticalPosition, labelWidth, labelHeight);
            AddUserDataLabel(userDataPanel, "Birthdate:", user.Birthdate.ToShortDateString(), firstColumnX, ref verticalPosition, labelWidth, labelHeight);
            AddUserDataLabel(userDataPanel, "Cell Phone:", user.CellPhone, firstColumnX, ref verticalPosition, labelWidth, labelHeight);

            // Agregar datos de la dirección del usuario
            if (user.Address != null)
            {
                verticalPosition += 10; // Añadir un espacio entre los datos del usuario y la dirección
                AddUserDataLabel(userDataPanel, "Between Street:", user.Address.BetweenStreet, firstColumnX, ref verticalPosition, labelWidth, labelHeight);
                AddUserDataLabel(userDataPanel, "Number:", user.Address.Number.ToString(), firstColumnX, ref verticalPosition, labelWidth, labelHeight);
                AddUserDataLabel(userDataPanel, "Postal Code:", user.Address.PostalCode.ToString(), firstColumnX, ref verticalPosition, labelWidth, labelHeight);
                AddUserDataLabel(userDataPanel, "City:", user.Address.City, firstColumnX, ref verticalPosition, labelWidth, labelHeight);
                // Agrega más datos de la dirección aquí...
            }

            // Agregar el panel de datos de usuario al panel principal
            panel.Controls.Add(userDataPanel);

            // Crear y agregar botones de acción
            Button viewPetButton = new Button
            {
                Text = "Visualizar mascota",
                Location = new Point(20, profilePictureBox.Bottom + 20),
                Size = new Size(150, 30)
            };
            viewPetButton.Click += ViewPetButton_Click;
            panel.Controls.Add(viewPetButton);

            Button editUserButton = new Button
            {
                Text = "Editar usuario",
                Location = new Point(20, viewPetButton.Bottom + 10),
                Size = new Size(150, 30)
            };
            editUserButton.Click += EditUserButton_Click;
            panel.Controls.Add(editUserButton);

            // Agregar el panel principal al formulario
            Controls.Add(panel);
        }

        private void AddUserDataLabel(Panel panel, string labelText, string valueText, int xPosition, ref int verticalPosition, int width, int height)
        {
            // Crear la etiqueta para mostrar el nombre del campo
            Label label = new Label
            {
                Text = labelText,
                Location = new Point(xPosition, verticalPosition),
                Width = width,
                Height = height,
                TextAlign = ContentAlignment.MiddleLeft
            };
            panel.Controls.Add(label);

            // Crear la etiqueta para mostrar el valor del campo
            Label valueLabel = new Label
            {
                Text = valueText,
                Location = new Point(xPosition + width, verticalPosition),
                Width = width,
                Height = height,
                TextAlign = ContentAlignment.MiddleLeft
            };
            panel.Controls.Add(valueLabel);

            // Incrementar la posición vertical para el siguiente par de etiquetas
            verticalPosition += height;
        }

        private void ViewPetButton_Click(object sender, EventArgs e)
        {
            // Crear y mostrar el formulario PetViewerForm
            PetViewerForm petViewerForm = new PetViewerForm(pets, lostAndFoundForm, isSave, user, userService, locationService, provinceService, emailService, authenticationService, lostFoundFormService, breedService, speciesService, petService, gMapControl);
            petViewerForm.Show();
        }

        private void EditUserButton_Click(object sender, EventArgs e)
        {
            // Lógica para editar el usuario
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public static ProfileViewerForm CreateProfileViewerForm(UserDto user, List<PetDto> pets, LostAndFoundForm lostAndFoundForm, bool isSave,
            IUserService userService, ILocationService locationService, IProvinceService provinceService, IEmailService emailService,
            IAuthenticationService authenticationService, ILostFoundFormService lostFoundFormService, IBreedService breedService, ISpeciesService speciesService, IPetService petService, GMapControl gMapControl)
        {
            if (profileViewerForm == null || profileViewerForm.IsDisposed)
            {
                profileViewerForm = new ProfileViewerForm(user, pets, lostAndFoundForm, isSave, userService, locationService, provinceService, emailService, authenticationService, lostFoundFormService, breedService, speciesService, petService, gMapControl);
            }
            return profileViewerForm;
        }
    }
}
