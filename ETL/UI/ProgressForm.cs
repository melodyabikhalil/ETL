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

        public const int PROGRESSBAR_MAXIMUM = 0;
        public const int PROGRESSBAR_VALUE = 1;
        public const int LABEL_ETL = 2;
        public const int LABEL_ACTION = 3;
        public const int ERROR = 4;
        public const int DONE = 5;

        public bool IsDead { get; set; }

        public ProgressForm()
        {
            InitializeComponent();
            _instance = this;
            progressBar.Value = 0;
            progressBar.Maximum = 100;
            etlLabel.Text = "Running...";
            actionLabel.Text = "Preparing migration...";
            UpdateProgressLabel();
            IsDead = false;
            CenterToScreen();
            this.ControlBox = false;
        }

        public void SetEtlLabel(string etlName)
        {
            etlLabel.Text = "Running " + etlName + " etl";
        }

        public void SetActionLabel(string action)
        {
            actionLabel.Text = action;
        }

        public void SetProgressBarValue(int value)
        {
            progressBar.Value = value;
            UpdateProgressLabel();
        }

        public void SetProgressBarMaximum(int max)
        {
            progressBar.Maximum = max;
            UpdateProgressLabel();
        }

        public void UpdateProgressLabel()
        {
            progressLabel.Text = progressBar.Value + "/" + progressBar.Maximum;
        }

        public void ShowError()
        {
            MessageBox.Show("An error occured, etl stopped. Check logs for more details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void ShowDone()
        {
            var pressed = MessageBox.Show("Job is done.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (pressed == DialogResult.OK)
            {
                this.Close();
            }
        }

        public void UpdateForm(int index, string value)
        {
            this.Invoke((MethodInvoker)delegate {
                switch (index)
                {
                    case PROGRESSBAR_MAXIMUM:
                        SetProgressBarMaximum(Int32.Parse(value));
                        break;
                    case PROGRESSBAR_VALUE:
                        SetProgressBarValue(Int32.Parse(value));
                        break;
                    case LABEL_ETL:
                        SetEtlLabel(value);
                        break;
                    case LABEL_ACTION:
                        SetActionLabel(value);
                        break;
                    case ERROR:
                        ShowError();
                        break;
                    case DONE:
                        ShowDone();
                        break;
                }
            });
        }
    }
}
