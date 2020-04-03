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
    public partial class ProgressForm : Form
    {
        public static ProgressForm _instance = new ProgressForm();

        public ProgressForm()
        {
            InitializeComponent();
            _instance = this;
        }

        public void SetEtlLabel(string etlName)
        {
            etlLabel.Text = "Running " + etlName;
        }

        public void SetActionLabel(string actionLabel)
        {
            etlLabel.Text = actionLabel;
        }

        public void SetProgressBarValue(int value)
        {
            progressBar.Value = value;
        }
    }
}
