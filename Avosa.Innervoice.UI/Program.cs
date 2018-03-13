using System;
using System.Windows.Forms;

namespace Avosa.Innervoice.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(IoC.Resolve<Main>());
        }
    }
}
