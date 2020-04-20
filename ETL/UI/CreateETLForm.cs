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
    public partial class CreateETLForm : Form
    {
        private Database src;
        private Database dest;
        private TableOrQuery srcTable;
        private Table destTable;
        private string ETLName = "";
        private bool isDspace;
        private string dspaceFolderPath;
        private string destTableName;
        private string sourceTableName;

        public CreateETLForm()
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
            dspacePathLabel.Visible = false;
            dspacePathTextBox.Visible = false;
        }

        private void FromETLNameToSrcDrstDbButton_Click(object sender, EventArgs e)
        {
            string etlName = ETLNameTextBox.Text;
            string srcDatabaseName = this.sourceDbComboBox.Text;
            string destDatabaseName = this.destinationDbComboBox.Text;
            string destTableName = this.destTableComboBox.Text;
            string srcTableName = this.srcTableOrQueriesComboBox.Text;
            string dspaceFolderPath = dspacePathTextBox.Text;
            this.dspaceFolderPath = dspaceFolderPath;
            bool isDspace = dspaceCheckBox.Checked;
            this.isDspace = isDspace;
            if ((isDspace && (dspaceFolderPath == null || dspaceFolderPath == "")) || (!isDspace && (etlName == "" || etlName == null || srcDatabaseName == null || srcDatabaseName == "" || destDatabaseName == null || destDatabaseName == "" || destTableName == null || destTableName == "" || srcTableName == null || srcTableName == "")))
            {
                MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ETLName = etlName;
            
                src = Global.GetDatabaseByName(srcDatabaseName);
                this.srcTableOrQueriesComboBox.Items.Clear();
                this.destTableComboBox.Items.Clear();
                this.srcTableOrQueriesComboBox.Items.AddRange(src.tablesNames.ToArray());
                this.srcTableOrQueriesComboBox.Items.AddRange(src.queriesNames.ToArray());
                if (!isDspace)
                {
                    dest = Global.GetDatabaseByName(destDatabaseName);
                    this.destTableComboBox.Items.AddRange(dest.tablesNames.ToArray());
                }
                else
                {
                    dest = new DSpaceDatabase();
                    ((DSpaceDatabase)dest).folderPath = dspaceFolderPath;
                    this.destTableComboBox.Enabled = false;
                }
                this.destTableComboBox.Items.AddRange(dest.tablesNames.ToArray());
           
                SetExpressionDataGridView();
                this.ExpressionTab.Enabled = true;
                this.ETLTabControl.SelectedTab = this.ExpressionTab;
            }

        }
        
        private void SetExpressionDataGridView()
        {
            this.srcColumnLabel.Text = "Source table columns: ";
            string destTableName;
            List<string> columnsNames;
            if (isDspace)
            {
                destTableName = "Dspace table";
                columnsNames = ((DSpaceDatabase)dest).columns;
            }
            else
            {
                destTableName = this.destTableComboBox.Text;
                dest.Close();
                dest.Connect();
                dest.SetDatatableSchema(destTableName);
                dest.Close();
                this.destTable = (Table)Global.GetTableByNameAndDbName(this.destinationDbComboBox.Text, destTableName);
                columnsNames = destTable.GetColumnsNames();
            }

            string srcTableName = this.srcTableOrQueriesComboBox.Text;

            bool clearRows = false;
            if (this.sourceTableName != null && this.destTableName != null)
            {
                if (this.sourceTableName != srcTableName || this.destTableName != destTableName)
                {
                    clearRows = true;
                }
            }
            this.sourceTableName = srcTableName;
            this.destTableName = destTableName;
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
                if (srcColumnsList == "")
                {
                    srcColumnsList += col;
                }
                else
                {
                    srcColumnsList += ", " + col;
                }
            }
            this.srcColumnLabel.Text = this.srcColumnLabel.Text + " " + srcColumnsList;
            List<string> expressionTypes = new List<string>(new string[] { "Replace", "Reg", "Map" });
            CreateComboBoxColumn("Expression Type", expressionTypes, "ExpressionType", 0, clearRows);
            CreateTexBoxColumn("Expression", false, "Expression", clearRows);
            CreateTexBoxColumn("Regular Expression", false, "RegularExpression", clearRows);

            CreateComboBoxColumn("Mapping Source column", srcTable.GetColumnsNames(), "MapColumnName", 3, clearRows);
            HashSet<string> sections = Global.mapDt.AsEnumerable().Select(r => r.Field<string>("MappingName")).ToHashSet();
            List<string> sectionNames = new List<string>();
            foreach (string section in sections)
            {
                sectionNames.Add(section);
            }
            CreateComboBoxColumn("Mapping Name", sectionNames, "MappingName", 4, clearRows);

            CreateTexBoxColumn("Table Name Destination", true, "TableNameDest", clearRows);
            foreach (DataGridViewRow Row in ExpressionDataGridView.Rows)
            {
                Row.Cells[5].Value = destTableName;
            }
            CreateComboBoxColumn("Column Destination", columnsNames, "ColumnDest", 6, clearRows);
        }

        private void CreateComboBoxColumn(string header, List<string> values, string name, int index, bool clearRows)
        {
            if (ExpressionDataGridView.Columns.Contains(name))
            {
                ((DataGridViewComboBoxColumn)ExpressionDataGridView.Columns[index]).DataSource = values;
                if (clearRows)
                {
                    ExpressionDataGridView.Rows.Clear();
                }
            }
            else
            {
                DataGridViewComboBoxColumn column =
                    new DataGridViewComboBoxColumn();
                {
                    column.Name = name;
                    column.Width = 127;
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
        }

        private void CreateTexBoxColumn(string header, bool readOnly, string name, bool clearRows)
        {
            if (clearRows)
            {
                ExpressionDataGridView.Rows.Clear();
            }

            if (!ExpressionDataGridView.Columns.Contains(name))
            {
                DataGridViewTextBoxColumn column =
                new DataGridViewTextBoxColumn();
                {
                    column.Name = name;
                    column.Width = 127;
                    column.HeaderText = header;
                    column.ReadOnly = readOnly;
                    column.DataPropertyName = name;
                    column.ValueType = typeof(string);
                    ExpressionDataGridView.Columns.Add(column);
                }
            }
        }

        private DataTable CreateExpressionDatatable()
        {
            DataTable dataTable = new DataTable();

            //create columns
            dataTable.Columns.Add("TableNameDest");
            dataTable.Columns.Add("ColumnDest");
            dataTable.Columns.Add("ExpressionType");
            dataTable.Columns.Add("MapColumnName");
            dataTable.Columns.Add("Expression");
            dataTable.Columns.Add("RegularExpression");
            dataTable.Columns.Add("MappingName");

            //populate data
            foreach (DataGridViewRow row in ExpressionDataGridView.Rows)
            {
                DataRow dr = dataTable.NewRow();
                dr["TableNameDest"] = row.Cells["TableNameDest"].Value;
                dr["ColumnDest"] = row.Cells["ColumnDest"].Value;
                dr["ExpressionType"] = row.Cells["ExpressionType"].Value;
                dr["MapColumnName"] = row.Cells["MapColumnName"].Value;
                dr["Expression"] = row.Cells["Expression"].Value;
                dr["MappingName"] = row.Cells["MappingName"].Value;
                dr["RegularExpression"] = row.Cells["RegularExpression"].Value;
                dataTable.Rows.Add(dr);
            }
            return dataTable;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SingleETL etl = new SingleETL(ETLName, src, dest, srcTable, destTable, this.CreateExpressionDatatable());
            etl.isDspaceDestination = isDspace;
            Global.etls.Add(etl);
            JsonHelper.SaveETL(etl, true);
            MessageBox.Show("ETL successfully created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ETLParent.ReloadEtlsListInMenu();
            this.Close();
        }

        private void ExpressionDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                for (int index = e.RowIndex; index <= e.RowIndex + e.RowCount - 1; index++)
                {
                    DataGridViewRow row = ExpressionDataGridView.Rows[index];
                    //Adds default value for the destination table name
                    if (row.Cells.Count > 1)
                    {
                        if (isDspace)
                        {
                            row.Cells[5].Value = "Dspace table";
                        }
                        else
                        {
                            row.Cells[5].Value = this.destTableComboBox.Text;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Helper.Log(ex.Message, "CreateETL-RowAdded");
            }
            
        }

        private void ExpressionDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string headerText = ExpressionDataGridView.Columns[e.ColumnIndex].HeaderText;
            if (!headerText.Equals("Expression Type")) return;
            DataGridViewRow currentRow = ExpressionDataGridView.Rows[e.RowIndex];
            if (currentRow.Cells["ExpressionType"].Value == null)
            {
                return;
            }
            if (currentRow.Cells["ExpressionType"].Value.Equals("Replace"))
            {
                // To disable a field we make it as read only and change its back color (changed only for the current row)
                currentRow.Cells["MapColumnName"].Value = "";
                currentRow.Cells["MapColumnName"].ReadOnly = true;
                currentRow.Cells["MapColumnName"].Style.BackColor = Color.LightGray;

                currentRow.Cells["RegularExpression"].Value = "";
                currentRow.Cells["RegularExpression"].ReadOnly = true;
                currentRow.Cells["RegularExpression"].Style.BackColor = Color.LightGray;

                currentRow.Cells["MappingName"].Value = "";
                currentRow.Cells["MappingName"].ReadOnly = true;
                currentRow.Cells["MappingName"].Style.BackColor = Color.LightGray;

                // We have to enable the other field that may be disabled earlier due to a previous expression type selection
                currentRow.Cells["Expression"].ReadOnly = false;
                currentRow.Cells["Expression"].Style.BackColor = Color.White;
            }
            else if (currentRow.Cells["ExpressionType"].Value.Equals("Map"))
            {
                currentRow.Cells["Expression"].ReadOnly = true;
                currentRow.Cells["Expression"].Value = "";
                currentRow.Cells["Expression"].Style.BackColor = Color.LightGray;

                currentRow.Cells["MapColumnName"].ReadOnly = false;
                currentRow.Cells["MapColumnName"].Style.BackColor = Color.White;
                currentRow.Cells["MappingName"].ReadOnly = false;
                currentRow.Cells["MappingName"].Style.BackColor = Color.White;

                currentRow.Cells["RegularExpression"].Value = "";
                currentRow.Cells["RegularExpression"].ReadOnly = true;
                currentRow.Cells["RegularExpression"].Style.BackColor = Color.LightGray;
            }
            else if (currentRow.Cells["ExpressionType"].Value.Equals("Reg"))
            {
                currentRow.Cells["Expression"].ReadOnly = false;
                currentRow.Cells["Expression"].Style.BackColor = Color.White;

                currentRow.Cells["MapColumnName"].Value = "";
                currentRow.Cells["MapColumnName"].ReadOnly = true;
                currentRow.Cells["MapColumnName"].Style.BackColor = Color.LightGray;

                currentRow.Cells["RegularExpression"].ReadOnly = false;
                currentRow.Cells["RegularExpression"].Style.BackColor = Color.White;

                currentRow.Cells["MappingName"].Value = "";
                currentRow.Cells["MappingName"].ReadOnly = true;
                currentRow.Cells["MappingName"].Style.BackColor = Color.LightGray;
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
                        DataCollection.Add("["+col+"]");
                    }
                    autoText.AutoCompleteCustomSource = DataCollection;
                }
            }
        }

        private void DspaceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = dspaceCheckBox.Checked;
            if (isChecked)
            {
                dspacePathLabel.Visible = true;
                dspacePathTextBox.Visible = true;
                destinationDbComboBox.Enabled = false;
                destTableComboBox.Enabled = false;
            }
            else
            {
                dspacePathLabel.Visible = false;
                dspacePathTextBox.Visible = false;
                destinationDbComboBox.Enabled = true;
                destTableComboBox.Enabled = true;
            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            HelpForm help = new HelpForm("\\HTML\\HelpETL.html");
            help.Show();
        }
    }
}
