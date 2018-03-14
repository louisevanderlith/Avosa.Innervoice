using Avosa.Innervoice.Core;
using Avosa.Innervoice.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avosa.Innervoice.UI
{
    public partial class ContactDetails : Form
    {
        public ContactDetails()
        {
            InitializeComponent();
        }

        public Contact Contact { get; set; }

        private void ContactDetails_Load(object sender, EventArgs e)
        {
            PopulateTypes();
        }

        private void PopulateTypes()
        {
            cboType.DataSource = EnumFunctions.GetContactTypes();
            cboType.ValueMember = "Key";
            cboType.DisplayMember = "Value";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Contact = new Contact
            {
                ContactType = (ContactType)cboType.SelectedValue,
                Value = txtValue.Text,
                IsActive = chkIsActive.Checked
            };

            DialogResult = DialogResult.OK;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
