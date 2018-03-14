using Avosa.Innervoice.Core;
using Avosa.Innervoice.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Avosa.Innervoice.UI
{
    public partial class CreateProfile : Form
    {
        private readonly IManageProfile _manageProfile;
        private string lastLogo;

        public CreateProfile(IManageProfile manageProfile)
        {
            _manageProfile = manageProfile;

            InitializeComponent();

            Profile = new Profile();
        }

        public Profile Profile { get; set; }

        private void CreateProfile_Load(object sender, EventArgs e)
        {
            PopulateTypes();
        }

        private void PopulateTypes()
        {
            cboType.DataSource = EnumFunctions.GetAddressTypes();
            cboType.ValueMember = "Key";
            cboType.DisplayMember = "Value";
        }

        public void Save()
        {
            Profile.Name = txtCompanyName.Text;
            Profile.RegistrationNo = txtRegNo.Text;
            Profile.Address = GetAddress();
            Profile.LogoID = SaveImage();

            _manageProfile.Create(Profile);
        }

        private Guid SaveImage()
        {
            var imageID = Guid.NewGuid();
            var imagePath = string.Format("./{0}.{1}", imageID.ToString(), lastLogo);

            picLogo.BackgroundImage.Save(imagePath);

            return imageID;
        }

        private Address GetAddress()
        {
            var address = new Address();

            address.StreetNo = txtStreetNo.Text;
            address.Street = txtStreet.Text;
            address.UnitNo = txtUnitNo.Text;
            address.EstateName = txtEstateName.Text;
            address.Suburb = txtSuburb.Text;
            address.City = txtCity.Text;
            address.Province = txtProvince.Text;
            address.PostalCode = txtPostalCode.Text;
            address.Coordinates = txtCoordinates.Text;
            address.Type = (AddressType)cboType.SelectedValue;

            return address;
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            var addContact = IoC.Resolve<ContactDetails>();

            if (addContact.ShowDialog() == DialogResult.OK)
            {
                Profile.ContactDetails.Add(addContact.Contact);
                var item = string.Format("{0}: {1}", addContact.Contact.ContactType, addContact.Contact.Value);
                lstContactDetails.Items.Add((Profile.ContactDetails.Count - 1).ToString(), item, 0);
            }
        }


        private void btnSelectLogo_Click(object sender, System.EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var filenameParts = fileDialog.FileName.Split('.');
                lastLogo = filenameParts[filenameParts.Length - 1];

                picLogo.BackgroundImage = Image.FromFile(fileDialog.FileName);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Save();

            DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}
