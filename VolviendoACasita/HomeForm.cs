using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VolviendoACasita.Business.Implementation;
using VolviendoACasita.Business.Interfaces;
using VolviendoACasita.Domain.Dto;
using VolviendoACasita.Domain.Entity;

namespace VolviendoACasita.UI
{
    public partial class HomeForm : Form
    {
        private readonly IUserService userService;
        private readonly ILostFoundFormService lostFoundFormService;
        private readonly IEmailService emailService;
        private readonly IProvinceService provinceService;
        private readonly ILocationService locationService;
        private readonly IAuthenticationService authenticationService;
        private readonly IBreedService breedService;
        private readonly ISpeciesService speciesService;
        private readonly IPetService petService;
        private bool isSave;
        private LostAndFoundForm lostAndFoundForm;

        private MapForm mapForm;

        private static HomeForm? homeForm;
        private UserDto user;
        private PetDto pet;
        private Label welcomeLabel;
        private PictureBox profilePictureBox;
        private Button logOutButton;
        private Button registerPetButton;
        private Button mapa;
        private GMapControl gMapControl;

        public HomeForm(UserDto user, IUserService userService, ILostFoundFormService lostFoundFormService, IEmailService emailService,
                        ILocationService locationService, IProvinceService provinceService, IAuthenticationService authenticationService,
                        IBreedService breedService, ISpeciesService speciesService, IPetService petService, GMapControl gMapControl)
        {
            this.user = user;
            this.userService = userService;
            this.lostFoundFormService = lostFoundFormService;
            this.emailService = emailService;
            this.locationService = locationService;
            this.provinceService = provinceService;
            this.authenticationService = authenticationService;
            this.breedService = breedService;
            this.speciesService = speciesService;
            this.petService = petService;
            this.gMapControl = gMapControl;
            InitializeComponent();
            InitializeWelcomeAndProfileControls();
            InitializeNavbarPanel();
            UpdateUIBasedOnLoginState();
            DisplayPetCards();
        }

        public List<LostFoundFormDto> GetAllPetInForm()
        {
            var form = lostFoundFormService.GetAllForm();
            return form;
        }

        private void InitializeWelcomeAndProfileControls()
        {
            // Crear y configurar el control Label para el mensaje de bienvenida
            welcomeLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(70, 12), // Ajusta según sea necesario para posicionar el texto correctamente
                Visible = false // Inicialmente oculto
            };
            Controls.Add(welcomeLabel);

            // Crear y configurar el control PictureBox para la imagen de perfil
            profilePictureBox = new PictureBox
            {
                Size = new Size(50, 50), // Ajusta según sea necesario
                Location = new Point(12, 12), // Posición a la izquierda superior del formulario
                SizeMode = PictureBoxSizeMode.Zoom, // Mantiene la proporción de la imagen
                Visible = false // Inicialmente oculto
            };
            Controls.Add(profilePictureBox);

        }

        private void InitializeNavbarPanel()
        {
            // Crear el Panel para la barra de navegación
            Panel navbarPanel = new Panel
            {
                Location = new Point(0, 0), // Coloca el panel en la parte superior del formulario
                Size = new Size(ClientSize.Width, 70), // Establece el tamaño del panel para que se extienda por todo el ancho del formulario
                BackColor = Color.LightGray // Color de fondo del panel
            };

            // Ajustar la posición y tamaño de los controles dentro del Panel
            RegisterButton.Location = new Point(navbarPanel.Width - 280, 15);
            RegisterButton.Size = new Size(130, 40);
            RegisterButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            LoginButton.Location = new Point(navbarPanel.Width - 140, 15);
            LoginButton.Size = new Size(130, 40);
            LoginButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Configurar el botón de cerrar sesión (Log Out)
            logOutButton = new Button
            {
                Text = "Cerrar Sesión",
                Size = new Size(130, 40),
                Location = new Point(navbarPanel.Width - 140, 15), // Posición a la derecha
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Visible = false // Inicialmente oculto
            };
            logOutButton.Click += LogOutButton_Click; // Añadir evento de clic

            registerPetButton = new Button
            {
                Text = "Registrar Mascota", // Establece el texto correcto del botón
                Size = new Size(180, 40), // Ajusta el ancho del botón para que el texto se muestre completamente
                Location = new Point(navbarPanel.Width - 320, 15), // Posición a la derecha
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Visible = false // Inicialmente oculto
            };
            registerPetButton.Click += registerPetButton_Click; // Añadir evento de clic

            mapa = new Button
            {
                Text = "Visualizar Mapa", // Establece el texto correcto del botón
                Size = new Size(180, 40), // Ajusta el ancho del botón para que el texto se muestre completamente
                Location = new Point(navbarPanel.Width - 500, 15), // Posición a la derecha
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Visible = false // Inicialmente oculto
            };
            mapa.Click += ViewMapButton_Click; // Añadir evento de clic

            welcomeLabel.Location = new Point(70, 20); // Posición del mensaje de bienvenida
            welcomeLabel.AutoSize = true; // Ajusta automáticamente el tamaño del Label
            welcomeLabel.Font = new Font("Arial", 12, FontStyle.Bold);

            profilePictureBox.Location = new Point(12, 10); // Posición de la imagen de perfil
            profilePictureBox.Size = new Size(50, 50);
            profilePictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            // Agregar controles al Panel
            navbarPanel.Controls.Add(RegisterButton);
            navbarPanel.Controls.Add(LoginButton);
            navbarPanel.Controls.Add(logOutButton); // Agregar el botón de cerrar sesión
            navbarPanel.Controls.Add(registerPetButton); // Agregar el botón de registrar mascota
            navbarPanel.Controls.Add(mapa); // Agregar el botón de registrar mascota
            navbarPanel.Controls.Add(welcomeLabel);
            navbarPanel.Controls.Add(profilePictureBox);

            // Agregar el Panel de la barra de navegación al formulario
            Controls.Add(navbarPanel);
        }

        private void ViewMapButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (mapForm == null || mapForm.IsDisposed)
                {
                    if (gMapControl == null || gMapControl.IsDisposed)
                    {
                        gMapControl = new GMapControl();
                        gMapControl.MapProvider = GMapProviders.GoogleMap;
                        gMapControl.Dock = DockStyle.Fill;
                        gMapControl.Position = new GMap.NET.PointLatLng(-34.6037, -58.3816); // Buenos Aires, Argentina
                        gMapControl.MinZoom = 2;
                        gMapControl.MaxZoom = 18;
                        gMapControl.Zoom = 10;
                    }
                    mapForm = new MapForm(lostFoundFormService, gMapControl);
                }
                 mapForm.Show();
            }
            catch (ObjectDisposedException ex)
            {
                MessageBox.Show($"ObjectDisposedException: {ex.ObjectName} - {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected exception: {ex.Message}");
            }
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            user = new UserDto();
            UpdateUIBasedOnLoginState();
        }

        private void registerPetButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var petRegister = new PetRegisterForm(0, null, true, user, userService, locationService, provinceService, emailService, authenticationService, lostFoundFormService, breedService, speciesService, petService, gMapControl);
            petRegister.Show();
        }

        private void UpdateControlsVisibility(bool isLoggedIn)
        {
            // Establecer la visibilidad de los controles según el estado de inicio de sesión
            welcomeLabel.Visible = isLoggedIn;
            profilePictureBox.Visible = isLoggedIn;
            RegisterButton.Visible = !isLoggedIn;
            LoginButton.Visible = !isLoggedIn;
            logOutButton.Visible = isLoggedIn;
            registerPetButton.Visible = isLoggedIn;
            mapa.Visible = isLoggedIn;
        }

        private void UpdateButtonsVisibility()
        {
            // Mostrar u ocultar botones según el estado de inicio de sesión
            bool isLoggedIn = IsLogged();
            bool canEdit = false; // Agrega aquí la lógica para determinar si el usuario puede editar

            // Mostrar botones según el estado de inicio de sesión y permisos
            if (isLoggedIn)
            {
                welcomeLabel.Text = $"Bienvenido/a, {user.UserName}!";
                welcomeLabel.Visible = true;
                profilePictureBox.ImageLocation = "https://img.freepik.com/vector-premium/icono-perfil-usuario-estilo-plano-ilustracion-vector-avatar-miembro-sobre-fondo-aislado-concepto-negocio-signo-permiso-humano_157943-15752.jpg";
                profilePictureBox.Visible = true;
                profilePictureBox.Click += new System.EventHandler(this.ProfilePictureBox_Click);
                // Agregar evento de clic a la imagen del perfil
                logOutButton.Visible = true;
                registerPetButton.Visible = true;
                mapa.Visible = true;
                // Ocultar botones de registro e inicio de sesión
                RegisterButton.Visible = false;
                LoginButton.Visible = false;

                // Determinar si el usuario puede editar
                canEdit = true; // Cambia esto con la lógica real para determinar si el usuario puede editar
            }
            else
            {
                welcomeLabel.Visible = false;
                profilePictureBox.Visible = false;
                logOutButton.Visible = false;
                registerPetButton.Visible = false;
                RegisterButton.Visible = true;
                LoginButton.Visible = true;
                mapa.Visible = false;
            }

            // Mostrar u ocultar el botón de editar según los permisos del usuario
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is Panel panel)
                {
                    foreach (Control panelControl in panel.Controls)
                    {
                        if (panelControl is Button button && button.Text == "Edit")
                        {
                            button.Visible = canEdit;
                        }
                    }
                }
            }
        }

        private void ProfilePictureBox_Click(object sender, EventArgs e)
        {
            // Abrir un nuevo formulario para editar la imagen del perfil, pasando el ID del usuario

            List<PetDto> userPets = petService.GetAllPetByUser(user.Id);
            ProfileViewerForm profileViewerForm = ProfileViewerForm.CreateProfileViewerForm(user, userPets, lostAndFoundForm, isSave, userService, locationService, provinceService, emailService, authenticationService, lostFoundFormService, breedService, speciesService, petService, gMapControl);
            profileViewerForm.Show();

        }

        private void UpdateUIBasedOnLoginState()
        {
            UpdateButtonsVisibility();
        }

        private bool IsLogged()
        {
            return user != null && user.Id > 0 && user.VerifyPassword;
        }

        private void DisplayPetCards()
        {
            // Limpiar el flowLayoutPanel1 antes de agregar nuevas tarjetas
            flowLayoutPanel1.Controls.Clear();

            // Permitir desplazamiento automático en el FlowLayoutPanel
            flowLayoutPanel1.AutoScroll = true;

            // Obtener la lista de LostFoundForm
            var forms = GetAllPetInForm();

            // Iterar sobre cada LostFoundForm
            foreach (var form in forms)
            {
                // Crear un panel con tamaño, margen y color de fondo
                Panel panel = new Panel
                {
                    Size = new Size(300, 350), // Tamaño más grande para acomodar PictureBox y Button
                    Margin = new Padding(10),
                    BackColor = Color.Transparent
                };

                // Obtener la URL de la imagen
                string imageUrl = form.Pet.Archive[0].Url;

                // Crear PictureBox con tamaño, modo de visualización y URL de la imagen
                PictureBox pictureBox = new PictureBox
                {
                    Size = new Size(250, 250), // Tamaño más grande para mejor visualización
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    ImageLocation = imageUrl
                };

                // Centrar el PictureBox en el panel
                pictureBox.Location = new Point(
                    (panel.Width - pictureBox.Width) / 2,
                    0 // Posición en la parte superior del Panel
                );

                // Crear un botón con texto, tamaño y margen
                Button viewMoreButton = new Button
                {
                    Text = "Ver más",
                    Size = new Size(panel.Width, 30), // Ancho igual al de la tarjeta
                    Margin = new Padding(0, 0, 0, 0)
                };
                viewMoreButton.Tag = form.Id;
                viewMoreButton.Click += viewMoreButton_Click; // Añadir evento de clic

                // Crear el botón de editar
                Button editButton = new Button
                {
                    Text = "Edit",
                    Size = new Size(panel.Width, 30), // Ancho igual al de la tarjeta
                    Margin = new Padding(0, 0, 0, 0),
                    Visible = false // Inicialmente no visible
                };
                editButton.Tag = form.Id;
                editButton.Click += editButton_Click; // Añadir evento de clic

                // Condición para mostrar el botón de editar
                if (ShouldShowEditButton(form))
                {
                    editButton.Visible = true;
                }

                // Posicionar los botones debajo del PictureBox, uno debajo del otro
                viewMoreButton.Location = new Point(
                    0, // Alineado a la izquierda
                    pictureBox.Bottom + 10 // Debajo del PictureBox con un margen adicional
                );
                editButton.Location = new Point(
                    0, // Alineado a la izquierda
                    viewMoreButton.Bottom + 10 // Debajo del botón "Ver más" con un margen adicional
                );

                panel.Controls.Add(pictureBox);
                panel.Controls.Add(viewMoreButton);
                if (editButton.Visible)
                {
                    panel.Controls.Add(editButton);
                }

                flowLayoutPanel1.Controls.Add(panel);
            }
        }

        private bool ShouldShowEditButton(LostFoundFormDto form)
        {
            return IsLogged() && form != null && form.CreatedById == user.Id;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            Button editButton = sender as Button;
            if (editButton != null)
            {
                int formId = (int)editButton.Tag;
                ShowLostAndFoundForm(formId, 0);
            }
        }

        private void ShowRegister(object sender, EventArgs e)
        {
            this.Hide();
            var register = new RegisterForm(userService, locationService, provinceService, emailService, authenticationService, lostFoundFormService, breedService, speciesService, petService, gMapControl);
            register.Show();

        }

        private void ShowLogin(object sender, EventArgs e)
        {
            if (user == null || user.Id == 0)
            {
                this.Hide();
                var loginForm = new LoginForm(userService, emailService, locationService, provinceService,
                    authenticationService, lostFoundFormService, breedService, speciesService, petService, gMapControl);
                loginForm.Show();
            }
            else if (!user.VerifyPassword)
            {
                this.Hide();
                var verifyPasswordForm = new PasswordConfimationForm(userService, emailService, locationService,
                    provinceService, authenticationService, lostFoundFormService, breedService, speciesService, petService, gMapControl);
                verifyPasswordForm.Show();
            }
        }

        private void ShowLostFormFoundViewerForm(int id)
        {
            var login = new LostAndFoundViewerForm(id, lostFoundFormService);
            login.Show();

        }

        private void ShowLostAndFoundForm(int id, int stateId)
        {
            var lostAndFound = new LostAndFoundForm(id, stateId, locationService, provinceService, lostFoundFormService, user, breedService, speciesService, petService, authenticationService, emailService, userService, gMapControl);
            lostAndFound.Show();

        }

        private void viewMoreButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                if (IsLogged())
                {
                    int formId = (int)clickedButton.Tag;
                    ShowLostFormFoundViewerForm(formId);                   
                }
                else
                {
                    ShowLogin(sender, e);
                }

            }
        }

        public static HomeForm CreateHomeForm(UserDto user, IUserService userService, ILostFoundFormService lostFoundFormService, IEmailService emailService,
            ILocationService locationService, IProvinceService provinceService, IAuthenticationService authenticationService, IBreedService breedService, ISpeciesService speciesService, IPetService petService, GMapControl gMapControl)
        {

            if (homeForm == null || homeForm.IsDisposed)
            {
                homeForm = new HomeForm(user, userService, lostFoundFormService, emailService, locationService, provinceService, authenticationService, breedService, speciesService, petService, gMapControl);
                
            }
            else
            {
                homeForm.user = user;                     
            }
            homeForm.UpdateControlsVisibility(homeForm.IsLogged());
            homeForm.DisplayPetCards();
            homeForm.UpdateButtonsVisibility();
            return homeForm;
        }
        private void btnLostForm_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                if (IsLogged())
                {
                    var formStateId = int.Parse((string)btnLostForm.Tag);
                    ShowLostAndFoundForm(0, formStateId);
                }
                else
                {
                    ShowLogin(sender, e);
                }

            }
        }

        private void btnFoundForm_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                if (IsLogged())
                {
                    var formStateId = int.Parse((string)btnFoundForm.Tag);
                    ShowLostAndFoundForm(0, formStateId);
                }
                else
                {
                    ShowLogin(sender, e);
                }

            }
        }
    }
}
