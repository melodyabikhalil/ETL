using ETL.UI;
using ETL.Utility;
using System;
using System.Windows.Forms;

namespace ETL
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
            SplashForm splashForm = new SplashForm();
            Global.SplashForm = splashForm;
            splashForm.Show();
            UIHelper.LoadSavedDataFromJsonFiles();
            splashForm.Close();
            Application.Run(new ETLParent());
        }
    }
}
