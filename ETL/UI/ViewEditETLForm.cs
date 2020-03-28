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
    public partial class ViewEditETLForm : Form
    {
        private SingleETL etl;
        public ViewEditETLForm(SingleETL singleETL)
        {
            InitializeComponent();
            this.etl = singleETL;
            this.etlNameLabel.Text += " " + singleETL.name;
            this.destinationDatabaseLabel.Text += " " + singleETL.destDb.databaseName;
            this.destinationTableLabel.Text += " " + singleETL.destTable.GetName();
            this.sourceDatabaseLabel.Text += " " + singleETL.srcDb.databaseName;
            this.sourceTableOrQueryLabel.Text += " " + singleETL.sourceTable.GetName();

            this.srcColumnLabel.Text = "Source table columns: ";
            string srcColumnsList = "";
            foreach (string col in singleETL.srcDb.GetTableOrQueryByName(singleETL.sourceTable.GetName()).GetColumnsNames())
            {
                srcColumnsList += col +", ";
            }
            srcColumnsList = srcColumnsList.Remove(srcColumnsList.Length - 2);
            this.srcColumnLabel.Text = this.srcColumnLabel.Text + " " + srcColumnsList;
            SetExpressionDataGridView();
            CenterToParent();
        }

        private void SetExpressionDataGridView()
        {
            List<string> expressionTypes = new List<string>(new string[] { "Replace", "Reg", "Map" });
            CreateComboBoxColumn("Expression Type", expressionTypes, "ExpressionType");
            CreateTexBoxColumn("Expression", false, "Expression");
            CreateTexBoxColumn("RegularExpression", false, "RegularExpression");
            CreateComboBoxColumn("Mapping Source column", etl.srcDb.GetTableOrQueryByName(etl.sourceTable.GetName()).GetColumnsNames(), "RegexpColumnName");
            CreateTexBoxColumn("Table Name Destination", true, "TableNameDest");
            CreateComboBoxColumn("Column Destination", etl.destDb.GetTable(etl.destTable.GetName()).GetColumnsNames(), "ColumnDest");
           
            HashSet<string> sections = Global.mapDt.AsEnumerable().Select(r => r.Field<string>("SectionName")).ToHashSet();
            List<string> sectionNames = new List<string>();
            foreach (string section in sections)
            {
                sectionNames.Add(section);
            }
            CreateComboBoxColumn("Mapping Name", sectionNames, "SectionName");
            ETLDataGridView.Rows.Add(etl.expressionDt.Rows.Count-1);
            foreach (DataGridViewRow Row in ETLDataGridView.Rows)
            {
                Row.Cells[4].Value = etl.destTable.GetName();
            }
            try
            {
                for (int i = 0; i < etl.expressionDt.Rows.Count; ++i)
                {
                    ETLDataGridView.Rows[i].Cells["ColumnDest"].Value = etl.expressionDt.Rows[i]["ColumnDest"];
                    ETLDataGridView.Rows[i].Cells["ExpressionType"].Value = etl.expressionDt.Rows[i]["ExpressionType"];
                    ETLDataGridView.Rows[i].Cells["RegexpColumnName"].Value = etl.expressionDt.Rows[i]["RegexpColumnName"];
                    ETLDataGridView.Rows[i].Cells["Expression"].Value = etl.expressionDt.Rows[i]["Expression"];
                    ETLDataGridView.Rows[i].Cells["RegularExpression"].Value = etl.expressionDt.Rows[i]["RegularExpression"];
                    ETLDataGridView.Rows[i].Cells["SectionName"].Value = etl.expressionDt.Rows[i]["SectionName"];

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void ETLDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void CreateComboBoxColumn(string header, List<string> values, string name)
        {
            DataGridViewComboBoxColumn column =
                new DataGridViewComboBoxColumn();
            {
                column.Name = name;
                column.Width = 145;
                column.MaxDropDownItems = 5;
                column.HeaderText = header;
                column.DataPropertyName = name;
                column.FlatStyle = FlatStyle.Flat;
                column.ValueType = typeof(string);
                if (values != null)
                {
                    column.DataSource = values;
                }
                ETLDataGridView.Columns.Add(column);
            }
        }

        private void CreateTexBoxColumn(string header, bool readOnly, string name)
        {
            DataGridViewTextBoxColumn column =
                new DataGridViewTextBoxColumn();
            {
                column.Name = name;
                column.Width = 145;
                column.HeaderText = header;
                column.ReadOnly = readOnly;
                column.DataPropertyName = name;
                column.ValueType = typeof(string);
                ETLDataGridView.Columns.Add(column);
            }
        }

        private DataTable CreateExpressionDatatable()
        {
            DataTable dataTable = new DataTable();

            //create columns
            dataTable.Columns.Add("TableNameDest");
            dataTable.Columns.Add("ColumnDest");
            dataTable.Columns.Add("ExpressionType");
            dataTable.Columns.Add("RegexpColumnName");
            dataTable.Columns.Add("Expression");
            dataTable.Columns.Add("RegularExpression");
            dataTable.Columns.Add("SectionName");

            //populate data
            foreach (DataGridViewRow row in ETLDataGridView.Rows)
            {
                DataRow dr = dataTable.NewRow();
                dr["TableNameDest"] = row.Cells["TableNameDest"].Value;
                dr["ColumnDest"] = row.Cells["ColumnDest"].Value;
                dr["ExpressionType"] = row.Cells["ExpressionType"].Value;
                dr["RegexpColumnName"] = row.Cells["RegexpColumnName"].Value;
                dr["Expression"] = row.Cells["Expression"].Value;
                dr["SectionName"] = row.Cells["SectionName"].Value;
                dr["RegularExpression"] = row.Cells["RegularExpression"].Value;
                dataTable.Rows.Add(dr);
            }
            return dataTable;
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            SingleETL oldEtl = Global.GetETLByName(etl.name);
            DataTable expressionDt = CreateExpressionDatatable();
            oldEtl.expressionDt = expressionDt;
            JobETL job = Global.GetJobContainingEtl(oldEtl);
            job.ReplaceEtlInJob(oldEtl);
            JsonHelper.SaveETL(oldEtl, true);
            JsonHelper.SaveEtlJob(job, true);
            MessageBox.Show("ETL successfully edited", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ETLParent.ReloadEtlsListInMenu();
            this.Close();
        }

        private void ETLDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string titleText = ETLDataGridView.Columns["Expression"].HeaderText;
            if (titleText.Equals("Expression"))
            {
                TextBox autoText = e.Control as TextBox;
                if (autoText != null)
                {
                    autoText.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
                    foreach (string col in this.etl.sourceTable.GetColumnsNames())
                    {
                        DataCollection.Add(col);
                    }
                    autoText.AutoCompleteCustomSource = DataCollection;
                }
            }
        }
    }
}
