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
using System.IO;

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
            this.ExpressionTab.Enabled = false;
            // Hide the tabs headers
            this.ETLTabControl.Appearance = TabAppearance.FlatButtons;
            this.ETLTabControl.ItemSize = new Size(0, 1);
            this.ETLTabControl.SizeMode = TabSizeMode.Fixed;

            for (int i = 0; i< Global.Databases.Count; ++i)
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
            }

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
            }

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
                srcColumnsList = srcColumnsList + ", " + col;
            }
            this.srcColumnLabel.Text = this.srcColumnLabel.Text + " " + srcColumnsList;
            this.destTable = (Table) Global.GetTableByNameAndDbName(this.destinationDbComboBox.Text, destTableName);
            CreateComboBoxColumn("Regexp/Mapping Source column", srcTable.GetColumnsNames(), "RegexpColumnName");
            CreateTexBoxColumn("Table Name Destination", true, "TableNameDest");
            foreach (DataGridViewRow Row in ExpressionDataGridView.Rows)
            {
                Row.Cells[1].Value = destTableName;
            }
            CreateComboBoxColumn("Column Destination", destTable.GetColumnsNames(), "ColumnDest");
            List<string> expressionTypes = new List<string>(new string[] { "Replace", "Reg", "Map" });
            CreateComboBoxColumn("Expression Type", expressionTypes, "ExpressionType");
            CreateTexBoxColumn("Expression", false, "Expression");
            HashSet<string> sections = Global.mapDt.AsEnumerable().Select(r => r.Field<string>("SectionName")).ToHashSet();
            List<string> sectionNames = new List<string>();
            foreach (string section in sections)
            {
                sectionNames.Add(section);
            }
            CreateComboBoxColumn("SectionName", sectionNames, "SectionName");
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
                dr["SectionName"] = row.Cells["SectionName"].Value;
                dataTable.Rows.Add(dr);
            }
            return dataTable;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SingleETL etl = new SingleETL(ETLName, src, dest, srcTable, destTable, this.CreateExpressionDatatable());
            Global.etls.Add(etl);
            JsonHelper.SaveETL(etl, true);
            MessageBox.Show("ETL successfully created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ETLParent.ReloadEtlsListInMenu();
            this.Close();
        }

        private void ExpressionDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int index = e.RowIndex; index <= e.RowIndex + e.RowCount - 1; index++)
            {
                DataGridViewRow row = ExpressionDataGridView.Rows[index];
                //Adds default value for the destination table name
                if (row.Cells.Count > 1) {
                    row.Cells[1].Value = this.destTableComboBox.Text;
                }
                
            }
        }

        private void ExpressionDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string headerText = ExpressionDataGridView.Columns[e.ColumnIndex].HeaderText;
            if (!headerText.Equals("Expression Type")) return;
            DataGridViewRow currentRow = ExpressionDataGridView.Rows[e.RowIndex];
            if (currentRow.Cells["ExpressionType"].Value.Equals("Replace"))
            {
                // To disable a field we make it as read only and change its back color (changed only for the current row)
                currentRow.Cells["RegexpColumnName"].Value = "";
                currentRow.Cells["RegexpColumnName"].ReadOnly = true;
                currentRow.Cells["RegexpColumnName"].Style.BackColor = Color.LightGray;

                currentRow.Cells["SectionName"].Value = "";
                currentRow.Cells["SectionName"].ReadOnly = true;
                currentRow.Cells["SectionName"].Style.BackColor = Color.LightGray;

                // We have to enable the other field that may be disabled earlier due to a previous expression type selection
                currentRow.Cells["Expression"].ReadOnly = false;
                currentRow.Cells["Expression"].Style.BackColor = Color.White;
            }
            else if (currentRow.Cells["ExpressionType"].Value.Equals("Map"))
            {
                currentRow.Cells["Expression"].ReadOnly = true;
                currentRow.Cells["Expression"].Value = "";
                currentRow.Cells["Expression"].Style.BackColor = Color.LightGray;

                currentRow.Cells["RegexpColumnName"].ReadOnly = false;
                currentRow.Cells["RegexpColumnName"].Style.BackColor = Color.White;
                currentRow.Cells["SectionName"].ReadOnly = false;
                currentRow.Cells["SectionName"].Style.BackColor = Color.White;
            }
            else if (currentRow.Cells["ExpressionType"].Value.Equals("Reg"))
            {
                currentRow.Cells["Expression"].ReadOnly = false;
                currentRow.Cells["Expression"].Style.BackColor = Color.White;
                currentRow.Cells["RegexpColumnName"].ReadOnly = false;
                currentRow.Cells["RegexpColumnName"].Style.BackColor = Color.White;

                currentRow.Cells["SectionName"].Value = "";
                currentRow.Cells["SectionName"].ReadOnly = true;
                currentRow.Cells["SectionName"].Style.BackColor = Color.LightGray;
            }

            return;
        }

        private void backToSrcDestTablesTabButton_Click(object sender, EventArgs e)
        {
            this.ETLTabControl.SelectedTab = this.ETLNameTab;
        }

        // Set the combobox of the source tables after choosing a source database
        private void sourceDbComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string srcDatabase = this.sourceDbComboBox.Text;
            src = Global.GetDatabaseByName(srcDatabase);
            this.srcTableOrQueriesComboBox.Items.Clear();
            this.srcTableOrQueriesComboBox.Items.AddRange(src.tablesNames.ToArray());
            this.srcTableOrQueriesComboBox.Items.AddRange(src.queriesNames.ToArray());
        }

        // Set the combobox of the destination tables after choosing a destination database
        private void destinationDbComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string destDatabase = this.destinationDbComboBox.Text;
            dest = Global.GetDatabaseByName(destDatabase);
            this.destTableComboBox.Items.Clear();
            this.destTableComboBox.Items.AddRange(dest.tablesNames.ToArray());
        }

        private void ExpressionDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string titleText = ExpressionDataGridView.Columns["Expression"].HeaderText;
            if (titleText.Equals("Expression"))
            {
                TextBox autoText = e.Control as TextBox;
                if (autoText != null)
                {
                    autoText.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
                    foreach(string col in this.srcTable.GetColumnsNames())
                    {
                        DataCollection.Add(col);
                    }
                    autoText.AutoCompleteCustomSource = DataCollection;
                }
            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("There is three types of expressions: Replace, Reg (Regular Expression) and Map.\r Usage examples:\r REPLACE: table1, FullName, Replace, null, [FirstName].[LastName], null \rREGULAR EXPRESSION: table1, Gender, Reg, Gender, ^[A - Za - z]{ 2}, null(takes the first two letters of the gender value) \rMAPPING: table1, Gender, Map, Gender, null, Gender(maps the gender value to another one using the mapping table)", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
