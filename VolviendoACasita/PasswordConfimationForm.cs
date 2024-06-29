using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VolviendoACasita.Business.Implementation;
using VolviendoACasita.Business.Interfaces;
using VolviendoACasita.Domain.Dto;

namespace VolviendoACasita.UI
{
    public partial class PasswordConfimationForm : Form
    {
        private readonly IUserService userService;
        private static PasswordConfimationForm? passwordConfimationForm;
        private readonly IEmailService emailService;
        private readonly IProvinceService provinceService;
        private readonly ILocationService locationService;
        private readonly IAuthenticationService authenticationService;
        private readonly ILostFoundFormService lostFoundFormService;
        private readonly IBreedService breedService;
        private readonly ISpeciesService speciesService;
        private readonly IPetService petService;
        private GMapControl gMapControl;
        public PasswordConfimationForm(IUserService userService, IEmailService emailService, ILocationService locationService,
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

        private async void button1_Click(object sender, EventArgs e)
        {
            var result = new ResultDto();

            var userDto = new UserDto { 
                UserName = txtUserPass.Text,
                OldPass = txtOldPass.Text,
                NewPass = txtNewPass.Text,
                ConfirmPassword = txtConfirmNewPass.Text
            };

            result = await userService.UpdatePassword(userDto);

            if (result.Errors.Count() > 0)
            {
                MessageBox.Show($"{result.Errors.First()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Se ha cambiado la contraseña correctamente");
                HomeForm homeForm = HomeForm.CreateHomeForm(result.UserDto, userService, lostFoundFormService, emailService, locationService, provinceService, authenticationService, breedService, speciesService, petService, gMapControl);
                this.Hide();
                homeForm.Show();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        public static PasswordConfimationForm CreatePasswordConfimation(IUserService userService, IEmailService emailService, ILocationService locationService,
            IProvinceService provinceService, IAuthenticationService authenticationService, ILostFoundFormService lostFoundFormService, IBreedService breedService, 
            ISpeciesService speciesService, IPetService petService, GMapControl gMapControl)
        {

            if (passwordConfimationForm == null || passwordConfimationForm.IsDisposed)
            {
                passwordConfimationForm = new PasswordConfimationForm(userService, emailService, locationService,
                 provinceService, authenticationService, lostFoundFormService, breedService, speciesService, petService, gMapControl);
            }
            return passwordConfimationForm;
        }
    }
}
