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
            SetEtlsDataGridView();
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string jobName = ETLJobNameTextBox.Text;
            if (jobName == null || jobName == "")
            {
                MessageBox.Show("Please choose a name for this job.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Global.GetJobByName(jobName) != null)
            {
                MessageBox.Show("Please choose another name for the job. This name already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable datatable = UIHelper.CreateDataTableFromDataGridView(etlJobDataGridView);
                List<string> etlNamesByOrder = Helper.ConvertDataColumnToList(datatable, "ETLs");
                List<SingleETL> etls = Global.GetEtlsFromNames(etlNamesByOrder);
                this.job.name = jobName;
                this.job.etls = etls;
                Global.jobETLs.Add(this.job);
                JsonHelper.SaveEtlJob(this.job, true);
                MessageBox.Show("Job successfully created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ETLParent.ReloadEtlJobsListInMenu();
                this.Close();
            }
        }
    }
}
