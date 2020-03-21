using ETL.Core;
using ETL.Utility;
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
    public partial class CreateETLJob : Form
    {
        private JobETL job = new JobETL();
        private List<string> etlNames = Global.GetEtlsNames();

        public CreateETLJob()
        {
            InitializeComponent();
            etlsTabPage.Enabled = false;
        }

        private void FromJobNameToEtlsListButton_Click(object sender, EventArgs e)
        {
            string name = ETLJobNameTextBox.Text;
            if (name == null || name == "")
            {
                MessageBox.Show("Please choose a name for the ETL Job", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Global.EtlJobNameAlreadyExists(name))
                {
                    MessageBox.Show("Another ETL job with the same name already exists. Please choose another name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.job.name = name;
                    etlsTabPage.Enabled = true;
                    this.SetEtlsDataGridView();
                    etlJobTabControl.SelectedTab = etlsTabPage;
                }
            }
        }

        private void SetEtlsDataGridView()
        {
            etlJobDataGridView.DataSource = new DataTable();
            CreateNumberColumn();
            CreateComboBoxColumn("ETLs", etlNames);
        }

        private void CreateComboBoxColumn(string header, List<string> values)
        {
            DataGridViewComboBoxColumn column =
                new DataGridViewComboBoxColumn();
            {
                column.Width = 170;
                column.MaxDropDownItems = 5;
                column.HeaderText = header;
                column.DataPropertyName = header;
                column.FlatStyle = FlatStyle.Flat;
                column.ValueType = typeof(string);
                if (values != null)
                {
                    column.DataSource = values;
                }
                etlJobDataGridView.Columns.Add(column);
            }
        }

        private void CreateNumberColumn()
        {
            DataGridViewColumn column =
                new DataGridViewTextBoxColumn();
            {
                column.Width = 100;
                column.HeaderText = "Order";
                column.DataPropertyName = "Order";
                column.ValueType = typeof(int);
                etlJobDataGridView.Columns.Add(column);
            }
        }

        private void EtlJobDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int rowsNumber = etlJobDataGridView.Rows.Count;
            etlJobDataGridView.Rows[rowsNumber - 1].Cells[0].Value = rowsNumber;
        }

        private void GoBackToNameTabFromETLsTabButton_Click(object sender, EventArgs e)
        {
            etlJobTabControl.SelectedTab = etlJobNameTabPage;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            DataTable datatable = UIHelper.CreateDataTableFromDataGridView(etlJobDataGridView);
            List<string> etlNamesByOrder = Helper.ConvertDataColumnToList(datatable, "ETLs");
            List<SingleETL> etls = Global.GetEtlsFromNames(etlNamesByOrder);
            this.job.etls = etls;
            Global.jobETLs.Add(this.job);
            JsonHelper.SaveEtlJob(this.job, true);
            MessageBox.Show("Job successfully created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ETLParent.ReloadEtlJobsListInMenu();
            this.Close();
        }
    }
}
