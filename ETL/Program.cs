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
            Start();
        }


        public static void Start()
        {
            SplashForm splashForm = new SplashForm();
            try
            {
                Global.SplashForm = splashForm;
                splashForm.Show();
                UIHelper.LoadSavedDataFromJsonFiles();
                splashForm.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helper.Log(e.Message, "LoadingSavedData");
            }

            Application.Run(new ETLParent());
        }
    }
}
