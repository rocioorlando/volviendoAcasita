using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using VolviendoACasita.Business.Implementation;
using VolviendoACasita.Business.Interfaces;
using VolviendoACasita.Domain.Dto;
using VolviendoACasita.Domain.Entity;
using VolviendoACasita.Domain.Util.Enums;

namespace VolviendoACasita.UI
{
    public partial class LostAndFoundForm : Form
    {

        private readonly IProvinceService provinceService;
        private readonly ILocationService locationService;
        private readonly ILostFoundFormService lostFoundFormService;
        private readonly IAuthenticationService authenticationService;
        private static LostAndFoundForm? lostAndFoundForm;
        private readonly IUserService userService;
        private readonly IBreedService breedService;
        private readonly ISpeciesService speciesService;
        private readonly IPetService petService;
        private UserDto user;
        private static RegisterForm? registerForm;
        private readonly IEmailService emailService;
        private int id;
        private int stateId;
        private PetDto pet;
        private GMapControl gMapControl;
        public LostAndFoundForm(int id, int stateId, ILocationService locationService, IProvinceService provinceService, ILostFoundFormService lostFoundFormService, 
            UserDto user, IBreedService breedService, ISpeciesService speciesService, IPetService petService, IAuthenticationService authenticationService,
            IEmailService emailService, IUserService userService, GMapControl gMapControl)
        {
            this.id = id;
            this.stateId = stateId;
            this.locationService = locationService;
            this.provinceService = provinceService;
            this.lostFoundFormService = lostFoundFormService;
            this.user = user;
            this.breedService = breedService;
            this.speciesService = speciesService;
            this.petService = petService;
            this.userService = userService;
            this.authenticationService = authenticationService;
            this.emailService = emailService;
            this.gMapControl = gMapControl;
            InitializeComponent();
            GetAllProvince();
            GetAllLocation();
            GetAllPetByUser();
            ShowFormIfIsEdited();
            UpdateUIBasedOnState();
          
        }

        public int GetId()
        {
            return id;
        }

        public int GetStateId()
        {
            return stateId;
        }


        private void ShowFormIfIsEdited()
        {
            if (id > 0)
            {
                var form = GetForm(id);
                FillForm(form);
            }
        }
        private LostFoundFormDto GetForm(int id)
        {
            return lostFoundFormService.Get(id);
        }

        public void FillForm(LostFoundFormDto form)
        {
            if (form != null)
            {
                txtContactPhone.Text = form.ContactPhone;
                if (form.LostFoundLocation != null)
                {
                    txtbeetwenStreet.Text = form.LostFoundLocation.BetweenStreet;
                    cmbLocation.SelectedValue = form.LostFoundLocation.LocationId;
                    cmbProvince.SelectedValue = form.LostFoundLocation.ProvinceId;
                    txtStreet.Text = form.LostFoundLocation.Street;
                    txtNumber.Text = form.LostFoundLocation.Number.ToString(); // Asegúrate de convertir el número a string
                    txtPostalCode.Text = form.LostFoundLocation.PostalCode.ToString();
                }
                dtPicker.Value = form.MeetingDate ?? DateTime.Now;
                checkIsOwner.Checked = form.CreatedById == user.Id;
                txtObservation.Text = form.Observation;
                lblLost.Visible = form.FormStatusId == 1;
                lblFound.Visible = form.FormStatusId == 2;
                stateId = form.FormStatusId;
                comboPet.SelectedValue = form.PetId;
            }
        }


        private void UpdateUIBasedOnState()
        {
            if (stateId == (int)LostAndFoundEnum.Lost)
            {
                lblLost.Visible = true;
                lblFound.Visible = false;
            }
            else
            {
                lblFound.Visible = true;
                lblLost.Visible = false;
            }
        }
        private LostFoundFormDto ConvertModelToEntity()
        {
            var form = GetForm(id);
            if (form == null) form = new LostFoundFormDto();
            form.Pet = null;
            form.PetId = pet != null && pet.Id > 0 ? pet.Id : (int)comboPet.SelectedValue;
            form.CreatedById = user.Id;
            form.PetLostFoundDate = DateTime.Now;
            form.ContactPhone = txtContactPhone.Text;
            form.CreatedDate = DateTime.Now;
            form.IsDeleted = false;
            form.Observation = txtObservation.Text;
            form.FormStatusId = stateId;
            var address = form.LostFoundLocation != null ? form.LostFoundLocation : new AddressDto();
            address.BetweenStreet = txtbeetwenStreet.Text;
            address.ProvinceId = (int)cmbProvince.SelectedValue;
            address.LocationId = (int)cmbLocation.SelectedValue;
            address.Number = !string.IsNullOrEmpty(txtNumber.Text) ? int.Parse(txtNumber.Text) : 0;
            address.PostalCode = !string.IsNullOrEmpty(txtPostalCode.Text) ? int.Parse(txtPostalCode.Text) : 0;
            address.City = "Buenos Aires";
            address.Street = txtStreet.Text;
            form.LostFoundLocation = address;
            return form;
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

        public void GetAllPetByUser()
        {
            var pets = petService.GetAllPetByUser(user.Id).ToList();
            comboPet.DataSource = pets;
            comboPet.DisplayMember = "Name";
            comboPet.ValueMember = "Id";
        }

        public List<LostFoundFormDto> GetAllPetInForm()
        {
            var form = lostFoundFormService.GetAllForm();
            return form;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var lostFoundForm = ConvertModelToEntity();
            if (lostFoundForm.PetId != null)
            {
                var result = new ResultDto();
                if (id > 0)
                {
                    result = await lostFoundFormService.UpdateFormWithExceptionHandlingAsync(lostFoundForm);
                }
                else
                {
                    result = await lostFoundFormService.AddFormWithExceptionHandling(lostFoundForm);
                }
                if (result.Errors.Count() > 0)
                {
                    MessageBox.Show($"{result.Errors.First()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var message = MessageBox.Show($"Se ha {(id > 0 ? "editado " : "creado")} el formulario con exito.");

                    if (message == DialogResult.OK)
                    {
                        var homeForm = HomeForm.CreateHomeForm(user, userService, lostFoundFormService, emailService, locationService, provinceService, authenticationService, breedService, speciesService, petService, gMapControl);
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show($"Debe agregar una mascota.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GetPet(PetDto newPet)
        {
            pet = newPet;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            var petRegister = PetRegisterForm.CreatPetRegisterForm(0, this, false, user, userService, lostFoundFormService, emailService, locationService, provinceService, authenticationService, breedService, speciesService, petService, gMapControl);
            petRegister.Close();
        }

        private void btnShowPet_Click(object sender, EventArgs e)
        {
            var petId = comboPet.SelectedValue != null ? (int)comboPet.SelectedValue : 0;
            bool isSave = false;
            var petRegister = new PetRegisterForm(id == 0 ? 0 : petId, this, isSave, user, userService, locationService, provinceService, emailService, authenticationService, lostFoundFormService, breedService, speciesService, petService, gMapControl);
            petRegister.Show();
        }

    }
}
