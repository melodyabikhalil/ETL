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
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
            CenterToScreen();
            FormBorderStyle = FormBorderStyle.None;
        }

        public void SetLoadingLabel(string label)
        {
            loadingLabel.Text = label;
        }
    }
}
