using Avosa.Innervoice.Core;
using Avosa.Innervoice.Data;
using System.Windows.Forms;

namespace Avosa.Innervoice.UI
{
    public partial class CreateProfile : Form
    {
        private readonly IManageProfile _manageProfile;

        public CreateProfile(IManageProfile manageProfile)
        {
            InitializeComponent();

            _manageProfile = manageProfile;
        }

        public void Save()
        {
            var profile = new Profile();

            _manageProfile.Create(profile);
        }
    }
}
