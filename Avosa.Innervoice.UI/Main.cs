using Avosa.Innervoice.Core;
using Avosa.Innervoice.Data;
using System.Windows.Forms;

namespace Avosa.Innervoice.UI
{
    public partial class Main : Form
    {
        private readonly IManageProfile _manageProfile;
        private Profile _profile;

        public Main(IManageProfile manageProfile)
        {
            InitializeComponent();

            _manageProfile = manageProfile;
        }

        private void Main_Load(object sender, System.EventArgs e)
        {
            if (!ProfileExists())
            {
                var createProfile = IoC.Resolve<CreateProfile>();
                createProfile.ShowDialog();
            }


        }

        private bool ProfileExists()
        {
            var profile = _manageProfile.GetProfile();
            var result = false;

            if ((result = profile != null))
            {
                _profile = profile;
            }

            return result;
        }
    }
}
