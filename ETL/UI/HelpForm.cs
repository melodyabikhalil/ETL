using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETL.UI
{
    public partial class HelpForm : Form
    {
        public HelpForm(string relativePath)
        {
            InitializeComponent();
            string path = @"" + Application.StartupPath + relativePath;
            this.webBrowser.Url = new Uri(path);
        }
    }
}
