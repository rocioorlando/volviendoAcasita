using GMap.NET.WindowsForms;
using System.Net.Http.Headers;
using VolviendoACasita.Business.Implementation;
using VolviendoACasita.Business.Interfaces;
using VolviendoACasita.DataAccess.Data;
using VolviendoACasita.Domain.Dto;
using VolviendoACasita.Domain.Entity;

namespace VolviendoACasita.UI
{
    public partial class RegisterForm : Form
    {
        private readonly IUserService userService;
        private static RegisterForm? registerForm;
        private readonly IProvinceService provinceService;
        private readonly ILocationService locationService;
        private readonly IEmailService emailService;
        private static LoginForm? loginForm;
        private readonly IAuthenticationService authenticationService;
        private readonly ILostFoundFormService lostFoundFormService;
        private readonly IBreedService breedService;
        private readonly ISpeciesService speciesService;
        private readonly IPetService petService;
        private GMapControl gMapControl;

        public RegisterForm(IUserService userService, ILocationService locationService, IProvinceService provinceService, IEmailService emailService,
            IAuthenticationService authenticationService, ILostFoundFormService lostFoundFormService, IBreedService breedService, 
            ISpeciesService speciesService, IPetService petService, GMapControl gMapControl)
        {
            this.userService = userService;
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
            GetAllProvince();
            GetAllLocation();
        }

        private void GetAllProvince()
        {
            cmbProvince.DataSource = provinceService.GetAll();
            cmbProvince.DisplayMember = "Description";
            cmbProvince.ValueMember = "Id";
        }

        private void GetAllLocation()
        {
            cmbLocation.DataSource = locationService.GetAll();
            cmbLocation.DisplayMember = "Description";
            cmbLocation.ValueMember = "Id";
        }

        private UserDto ConvertModelToDto()
        {
            var address = new AddressDto
            {
                BetweenStreet = txtbeetwenStreet.Text,
                City = txtCity.Text,
                Number = !string.IsNullOrEmpty(txtNumber.Text) ? int.Parse(txtNumber.Text) : 0,
                PostalCode = !string.IsNullOrEmpty(txtPostalCode.Text) ? int.Parse(txtPostalCode.Text) : 0,
                ProvinceId = (int)cmbProvince.SelectedValue,
                LocationId = (int)cmbLocation.SelectedValue,
                Street = txtStreet.Text
            };

            var userDto = new UserDto
            {
                UserName = txtUsername.Text,
                Name = txtName.Text,
                LastName = txtlastName.Text,
                Dni = txtDni.Text,
                Birthdate = dtPicker.Value,
                CellPhone = txtCellPhone.Text,
                CreatedDate = DateTime.Now,
                Password = userService.SetRandomPassword(),
                Address = address,
                Email = txtEmail.Text
            };

            return userDto;
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            var userDto = ConvertModelToDto();
            var result = new ResultDto();
            result = await userService.AddUserWithExceptionHandling(userDto);
            if (result.Errors.Count() > 0)
            {
                MessageBox.Show($"{result.Errors.First()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SendEmail(userDto);
                var message = MessageBox.Show("Se le ha enviado una contraseña provisoria al mail ingresado");

                if (message == DialogResult.OK)
                {
                    HomeForm homeForm = HomeForm.CreateHomeForm(userDto, userService, lostFoundFormService, emailService, locationService, provinceService, authenticationService, breedService, speciesService, petService, gMapControl);
                    homeForm.Show();
                    this.Hide();

                }
            }
        }

        private void SendEmail(UserDto userDto)
        {
            try
            {
                emailService.SendEmail(userDto.Email, "Volviendo a casita - Nueva contraseña", "Su contraseña nueva es: " + userDto.Password);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            HomeForm homeForm = HomeForm.CreateHomeForm(null, userService, lostFoundFormService, emailService, locationService, provinceService, authenticationService, breedService, speciesService, petService, gMapControl);
            homeForm.Show();
            this.Close();
        }


        public static RegisterForm CreateRegisterForm(IUserService userService, ILocationService locationService, IProvinceService provinceService,
            IEmailService emailService, IAuthenticationService authenticationService, ILostFoundFormService lostFoundFormService, IBreedService breedService,
            ISpeciesService speciesService, IPetService petService, GMapControl gMapControl)
        {

            if (registerForm == null || registerForm.IsDisposed)
            {
                registerForm = new RegisterForm(userService, locationService, provinceService, emailService, authenticationService, lostFoundFormService, breedService, speciesService, petService, gMapControl);
            }
            return registerForm;
        }
    }
}
