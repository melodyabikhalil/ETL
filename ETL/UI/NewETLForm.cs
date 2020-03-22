using ETL.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ETL.Utility;

namespace ETL.UI
{
    public partial class NewETLForm : Form
    {
        private Dictionary<int, String> dbDictionary = new Dictionary<int, string>();
        private Dictionary<int, String> srcTablesDictionary = new Dictionary<int, string>();
        private Dictionary<int, String> destTablesDictionary = new Dictionary<int, string>();
        private Database src;
        private Database dest;
        private TableOrQuery srcTable;
        private Table destTable;
        string ETLName = "";

        public NewETLForm()
        {
            InitializeComponent();
            this.SrcDestDbTab.Enabled = false;
            this.SrcDestTablesTab.Enabled = false;
            this.ExpressionTab.Enabled = false;
            
            for(int i = 0; i< Global.Databases.Count; ++i)
            {
                sourceDbComboBox.Items.Insert(i, Global.Databases[i].databaseName);
                destinationDbComboBox.Items.Insert(i, Global.Databases[i].databaseName);
            }
        }

        private void FromETLNameToSrcDrstDbButton_Click(object sender, EventArgs e)
        {
            string etlName = ETLNameTextBox.Text;
            if (etlName == "" || etlName == null)
            {
                MessageBox.Show("Please choose a name for this new ETL to proceed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ETLName = etlName;
                this.SrcDestDbTab.Enabled = true;
                this.ETLTabControl.SelectedTab = this.SrcDestDbTab;
            }
        }

        private void BackFromSrcDestDbToETLNameButton_Click(object sender, EventArgs e)
        { 
            this.ETLTabControl.SelectedTab = this.ETLNameTab;
        }

        private void FromSrcDestDbToSrcDestTablesButton_Click(object sender, EventArgs e)
        {
            string srcDatabase = this.sourceDbComboBox.Text;
            string destDatabase = this.destinationDbComboBox.Text;
            if (srcDatabase == null || srcDatabase == "" || destDatabase == null || destDatabase == "")
            {
                MessageBox.Show("Please choose source & destination databases to proceed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                src = Global.GetDatabaseByName(srcDatabase);
                dest = Global.GetDatabaseByName(destDatabase);
                this.srcTableOrQueriesComboBox.Items.Clear();
                this.destTableComboBox.Items.Clear();
                this.srcTableOrQueriesComboBox.Items.AddRange(src.tablesNames.ToArray());
                this.srcTableOrQueriesComboBox.Items.AddRange(src.queriesNames.ToArray());
                this.destTableComboBox.Items.AddRange(dest.tablesNames.ToArray());
                this.SrcDestTablesTab.Enabled = true;
                this.ETLTabControl.SelectedTab = this.SrcDestTablesTab;
            }
        }

        private void SetExpressionDataGridView()
        {
            this.srcColumnLabel.Text = "Source table columns: ";
            string destTableName = this.destTableComboBox.Text;
            dest.Close();
            dest.Connect();
            dest.SetDatatableSchema(destTableName);
            dest.Close();
            string srcTableName = this.srcTableOrQueriesComboBox.Text;
            List<string> sourceDatabaseTablesNames = this.src.tablesNames;
            if (sourceDatabaseTablesNames.Contains(srcTableName))
            {
                src.Close();
                src.Connect();
                src.SetDatatableSchema(srcTableName);
                src.Close();
                this.srcTable = Global.GetTableByNameAndDbName(this.sourceDbComboBox.Text, srcTableName);
            }
            else //means this source is a query not a table
            {
                this.srcTable = this.src.GetQuery(srcTableName);
            }
            string srcColumnsList = "";
            foreach(string col in srcTable.GetColumnsNames())
            {
                srcColumnsList = srcColumnsList + " " + col;
            }
            this.srcColumnLabel.Text = this.srcColumnLabel.Text + " " + srcColumnsList;
            this.destTable = (Table) Global.GetTableByNameAndDbName(this.destinationDbComboBox.Text, destTableName);
            CreateTexBoxColumn("Table Name Destination", true, "TableNameDest");
            foreach (DataGridViewRow Row in ExpressionDataGridView.Rows)
            {
                Row.Cells[0].Value = destTableName;
            }
            CreateComboBoxColumn("Column Destination", destTable.GetColumnsNames(), "ColumnDest");
            List<string> expressionTypes = new List<string>(new string[] { "Replace", "Reg", "Map" });
            CreateComboBoxColumn("Expression Type", expressionTypes, "ExpressionType");
            CreateComboBoxColumn("Regexp Column Name", srcTable.GetColumnsNames(), "RegexpColumnName");
            CreateTexBoxColumn("Expression", false, "Expression");
            HashSet<string> sections = Global.mapDt.AsEnumerable().Select(r => r.Field<string>("Section Name")).ToHashSet();
            List<string> sectionNames = new List<string>();
            foreach (string section in sections)
            {
                sectionNames.Add(section);
            }
            CreateComboBoxColumn("Section Name", sectionNames, "Section Name");
        }

        private void FromSrcDestTablesToExpression_Click(object sender, EventArgs e)
        {
            string destTableName = this.destTableComboBox.Text;
            string srcTableName = this.srcTableOrQueriesComboBox.Text;
                if (destTableName == null || destTableName == "" || srcTableName == null || srcTableName == "")
            {
                MessageBox.Show("Please choose source & destination tables (or queries) to proceed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SetExpressionDataGridView();
                this.ExpressionTab.Enabled = true;
                this.ETLTabControl.SelectedTab = this.ExpressionTab;
            }
        }

        private void BackToSrcDestDbFromSrcDestTables_Click(object sender, EventArgs e)
        {
            this.ETLTabControl.SelectedTab = this.SrcDestDbTab;
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
                ExpressionDataGridView.Columns.Add(column);
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
                ExpressionDataGridView.Columns.Add(column);
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
            dataTable.Columns.Add("SectionName");

            //populate data
            foreach (DataGridViewRow row in ExpressionDataGridView.Rows)
            {
                DataRow dr = dataTable.NewRow();
                dr["TableNameDest"] = row.Cells["TableNameDest"].Value;
                dr["ColumnDest"] = row.Cells["ColumnDest"].Value;
                dr["ExpressionType"] = row.Cells["ExpressionType"].Value;
                dr["RegexpColumnName"] = row.Cells["RegexpColumnName"].Value;
                dr["Expression"] = row.Cells["Expression"].Value;
                dr["SectionName"] = row.Cells["Section Name"].Value;
                dataTable.Rows.Add(dr);
            }
            return dataTable;
        }

        private void BackToSrcDestTablesTabButton_Click(object sender, EventArgs e)
        {
            this.ETLTabControl.SelectedTab = this.SrcDestTablesTab;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SingleETL etl = new SingleETL(ETLName, src, dest, srcTable, destTable, this.CreateExpressionDatatable());
            Global.etls.Add(etl);
            JsonHelper.SaveETL(etl, true);
            MessageBox.Show("ETL successfully created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ETLParent.SetEtlsMenu();
            this.Close();
        }

        private void ExpressionDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int index = e.RowIndex; index <= e.RowIndex + e.RowCount - 1; index++)
            {
                DataGridViewRow row = ExpressionDataGridView.Rows[index];
                row.Cells[0].Value = this.destTableComboBox.Text;
            }
        }
    }
}
