using GMap.NET.WindowsForms;
using VolviendoACasita.Business.Implementation;
using VolviendoACasita.Business.Interfaces;
using VolviendoACasita.Domain.Entity;
using VolviendoACasita.UI;

namespace VolviendoACasita
{
    public partial class LoginForm : Form
    {
        private readonly IUserService userService;
        private readonly IEmailService emailService;
        private static LoginForm? loginForm;
        private readonly IProvinceService provinceService;
        private readonly ILocationService locationService;
        private readonly IAuthenticationService authenticationService;
        private readonly ILostFoundFormService lostFoundFormService;
        private readonly IBreedService breedService;
        private readonly ISpeciesService speciesService;
        private readonly IPetService petService;
        private GMapControl gMapControl;

        public LoginForm(IUserService userService, IEmailService emailService, ILocationService locationService, 
            IProvinceService provinceService, IAuthenticationService authenticationService, ILostFoundFormService lostFoundFormService, 
            IBreedService breedService, ISpeciesService speciesService, IPetService petService, GMapControl gMapControl)
        {
            this.userService = userService;
            this.emailService = emailService;
            this.provinceService = provinceService;
            this.locationService = locationService;
            this.authenticationService = authenticationService;
            this.lostFoundFormService = lostFoundFormService;
            this.breedService = breedService;
            this.speciesService = speciesService;
            this.petService = petService;
            this.gMapControl = gMapControl;
            InitializeComponent();
        }


        private void Login_Click(object sender, EventArgs e)
        {
            // Solicitar nombre de usuario y contraseña al usuario
            string usernameOrEmail = txtUserName.Text;
            string password = txtPassword.Text;

            // Autenticar al usuario
            var result = authenticationService.AuthenticateUser(usernameOrEmail, password);

            if (result.IsSuccess)
            {
                if (result.UserDto.VerifyPassword) 
                { 
                    HomeForm homeForm = HomeForm.CreateHomeForm(result.UserDto, userService, lostFoundFormService, emailService, locationService, provinceService, authenticationService, breedService, speciesService, petService, gMapControl);
                    this.Close();
                    homeForm.Show();
                } 
                else
                {
                    var passwordConfimationForm = new PasswordConfimationForm(userService, emailService, locationService,
                        provinceService, authenticationService, lostFoundFormService, breedService, speciesService, petService, gMapControl);
                    this.Close();
                    passwordConfimationForm.Show();
                }
            }
            else
            {
                // Mostrar mensaje de error
                MessageBox.Show(result.Errors[0], "Error de inicio de sesión");

            }
        }

        private void lnkLblRegistro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = RegisterForm.CreateRegisterForm(userService, locationService, provinceService, emailService, authenticationService, lostFoundFormService, breedService, speciesService, petService, gMapControl);
            if (registerForm != null)
            {
                registerForm.Show();
                this.Close();
            }

        }
        public static LoginForm CreateLoginForm(IUserService userService, IEmailService emailService, 
            ILocationService locationService, IProvinceService provinceService, IAuthenticationService authenticationService, ILostFoundFormService lostFoundFormService, IBreedService breedService, ISpeciesService speciesService, IPetService petService, GMapControl gMapControl)
        {

            if (loginForm == null || loginForm.IsDisposed)
            {
                loginForm = new LoginForm(userService, emailService, locationService, provinceService, authenticationService, lostFoundFormService, breedService, speciesService, petService, gMapControl);
            }
            return loginForm;
        }


    }
}
