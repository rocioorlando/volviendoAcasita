using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using VolviendoACasita.Business.Implementation;
using VolviendoACasita.Business.Interfaces;
using VolviendoACasita.Domain.Dto;
using VolviendoACasita.Domain.Entity;
using VolviendoACasita.Domain.Util.Enums;

namespace VolviendoACasita.UI
{
    public partial class PetRegisterForm : Form
    {
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
        private UserDto user;
        private bool isSave;
        private int petId;
        private LostAndFoundForm lostAndFoundForm;
        private GMapControl gMapControl;

        public PetRegisterForm(int petId, LostAndFoundForm lostAndFoundForm, bool isSave, UserDto user, IUserService userService, ILocationService locationService, IProvinceService provinceService, IEmailService emailService,
            IAuthenticationService authenticationService, ILostFoundFormService lostFoundFormService, IBreedService breedService, ISpeciesService speciesService, IPetService petService, GMapControl gMapControl)
        {
            this.lostAndFoundForm = lostAndFoundForm;
            this.isSave = isSave;
            this.user = user;
            this.petId = petId;
            this.userService = userService;
            this.locationService = locationService;
            this.provinceService = provinceService;
            this.emailService = emailService;
            this.authenticationService = authenticationService;
            this.lostFoundFormService = lostFoundFormService;
            this.breedService = breedService;
            this.speciesService = speciesService;
            this.petService = petService;
            InitializeComponent();
            GetAllSpecies();
            GetAllBreeds();
            FillSizeComboBox();
            ShowPetIfIsEdited();            
        }

        private void ShowPetIfIsEdited()
        {
            if (petId > 0)
            {
                var pet = GetPet(petId);
                FillPet(pet);
            }
        }

        private PetDto GetPet(int id)
        {
            return petService.GetPet(id);
        }

        private void FillPet(PetDto pet)
        {
            txtName.Text = pet.Name;
            txtAge.Text = pet.Age?.ToString();
            txtWeight.Text = pet.Weight?.ToString();
            txtColor.Text = pet.Color;
            txtUrl.Text = pet.Archive.FirstOrDefault().Url;
            checkCastrated.Checked = pet.IsCastrated ?? false;
            checkIsOnMedication.Checked = pet.IsOnMedication ?? false;
            txtRespondsTo.Text = pet.RespondsTo;
            checkIsVaccinated.Checked = pet.IsVaccinated ?? false;
            txtMedicationNotes.Text = pet.MedicationNotes;
            checkIsOwner.Checked = pet.IsOwner;
            checkHasVifVilef.Checked = pet.HasVifVilef ?? false;
            checkHasTag.Checked = pet.HasTag ?? false;
            cmbBreed.SelectedValue = pet.BreedId;
            cmbSpecies.SelectedValue = pet.Breed?.SpeciesId;
            txtUrl.Text = pet.Archive?.FirstOrDefault()?.Url;
            cmbSize.SelectedValue = pet.SizeId;
        }


        private void GetAllSpecies()
        {
            cmbSpecies.DataSource = speciesService.GetAll();
            cmbSpecies.DisplayMember = "Description";
            cmbSpecies.ValueMember = "Id";
        }

        private void GetAllBreeds()
        {
            SetBreedCombo();
            cmbBreed.DisplayMember = "Description";
            cmbBreed.ValueMember = "Id";
        }

        private void FillSizeComboBox()
        {
            var sizeValues = Enum.GetValues(typeof(SizeEnum))
                .Cast<SizeEnum>()
                .Select(e => new { Id = (int)e, Name = e.ToString() })
                .ToList();

            cmbSize.DataSource = sizeValues;
            cmbSize.DisplayMember = "Name";
            cmbSize.ValueMember = "Id";
        }


        private SizeEnum GetSelectedSize()
        {
            if (cmbSize.SelectedValue != null && Enum.TryParse(cmbSize.SelectedValue.ToString(), out SizeEnum sizeEnumValue))
            {
                return sizeEnumValue;
            }
            else
            {
                MessageBox.Show("No se pudo obtener el valor del tamaño seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return SizeEnum.Pequeño;
            }
        }

        private PetDto ConvertModelToEntity()
        {
            var pet = GetPet(petId);
            if (pet == null) pet = new PetDto();

            var speciesId = cmbSpecies.SelectedValue as int?;
            var breedId = cmbBreed.SelectedValue as int?;
            var sizeEnum = GetSelectedSize();
            var sizeId = (int)sizeEnum;

            pet.BreedId = breedId.Value;
            pet.Breed = null;
            pet.Name = txtName.Text;
            pet.Age = !string.IsNullOrEmpty(txtAge.Text) ? int.Parse(txtAge.Text) : 0;
            pet.Weight = !string.IsNullOrEmpty(txtWeight.Text) ? decimal.Parse(txtWeight.Text) : 0;
            pet.Color = txtColor.Text;
            pet.IsCastrated = checkCastrated.Checked;
            pet.IsOnMedication = checkIsOnMedication.Checked;
            pet.RespondsTo = txtRespondsTo.Text;
            pet.IsVaccinated = checkIsVaccinated.Checked;
            pet.MedicationNotes = txtMedicationNotes.Text;
            pet.IsOwner = checkIsOwner.Checked;
            pet.HasVifVilef = checkHasVifVilef.Checked;
            pet.HasTag = checkHasTag.Checked;
            pet.CreatedDate = DateTime.Now;
            pet.UserId = user.Id;
            pet.SizeId = sizeId;

            if (pet.Archive == null)
            {
                pet.Archive = new List<ArchiveDto>();
            }

            AddUrlToArchive(pet.Archive, txtUrl.Text);

            return pet;
        }

        private void AddUrlToArchive(List<ArchiveDto> archives, string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                var existingArchive = archives.FirstOrDefault(a => a.Url == url);
                if (existingArchive == null)
                {
                    archives.Add(new ArchiveDto { Url = url, Description = "Descripcion" });
                }
                else
                {
                    existingArchive.Url = url; 
                }
            }
        }

        private async void btnCorfirm_Click(object sender, EventArgs e)
        {
            var pet = ConvertModelToEntity();

            var result = new ResultDto();
            if (isSave)
            {
                result = petService.AddPetWithExceptionHandling(pet);
                if (result.Errors.Count() > 0)
                {
                    MessageBox.Show($"{result.Errors.First()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    HomeForm homeForm = HomeForm.CreateHomeForm(user, userService, lostFoundFormService, emailService, locationService, provinceService, authenticationService, breedService, speciesService, petService, gMapControl);
                    homeForm.Show();
                    this.Hide();
                }
            }
            else
            {
                result = await petService.UpdateFormWithExceptionHandlingAsync(pet);
                if (result.Errors.Count() > 0)
                {
                    MessageBox.Show($"{result.Errors.First()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (lostAndFoundForm != null && !lostAndFoundForm.IsDisposed)
                    {
                        lostAndFoundForm.GetPet(pet);
                        lostAndFoundForm.GetAllPetByUser();
                        lostAndFoundForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        var lost = new LostAndFoundForm(lostAndFoundForm?.GetId() ?? default, lostAndFoundForm?.GetStateId() ?? default, locationService, provinceService, lostFoundFormService, user, breedService, speciesService, petService, authenticationService, emailService, userService, gMapControl);
                        lost.GetPet(pet);
                        lost.Show();
                        this.Hide();
                    }

                }

            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {           
            HomeForm homeForm = HomeForm.CreateHomeForm(user, userService, lostFoundFormService, emailService, locationService, provinceService, authenticationService, breedService, speciesService, petService, gMapControl);
            homeForm.Show();
            this.Close();
        }

        public static PetRegisterForm CreatPetRegisterForm(int petId, LostAndFoundForm lostAndFoundForm, bool isSave, UserDto user, IUserService userService, ILostFoundFormService lostFoundFormService, IEmailService emailService,
            ILocationService locationService, IProvinceService provinceService, IAuthenticationService authenticationService, IBreedService breedService, ISpeciesService speciesService, IPetService petService, GMapControl gMapControl)
        {

            if (petRegisterForm == null || petRegisterForm.IsDisposed)
            {
                petRegisterForm = new PetRegisterForm(petId, lostAndFoundForm, isSave, user, userService, locationService, provinceService, emailService, authenticationService, lostFoundFormService, breedService, speciesService, petService, gMapControl);
            }
            else
            {
                petRegisterForm.user = user;
            }
            return petRegisterForm;
        }

        private void cmbSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetBreedCombo();
        }

        private void SetBreedCombo()
        {
            cmbBreed.DataSource = breedService.GetAll().Where(x => x.SpeciesId == (cmbSpecies.SelectedValue as int?)).ToList();
        }

    }
}
