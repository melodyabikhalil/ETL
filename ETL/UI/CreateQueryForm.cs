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
    public partial class CreateQueryForm : Form
    {
        private JoinQuery joinQuery;
        private List<string> mainTableOptions = new List<string>();

        public CreateQueryForm()
        {
            InitializeComponent();
            this.joinQuery = new JoinQuery();
            this.buildQueryTabPage.Enabled = false;
            this.selectColumnsTabPage.Enabled = false;
            this.queryPreviewTabPage.Enabled = false;
            this.AcceptButton = saveButton;
        }

        public void SetJoinQuery(JoinQuery newJoinQuery)
        {
            joinQuery = newJoinQuery;
            this.mainTableOptions = joinQuery.database.tablesNames;
            foreach (string table in mainTableOptions)
            {
                this.mainTableCombobox.Items.Add(table);
            }
        }

        private void GoToBuildQueryTabFromMainTableTabButton_Click(object sender, EventArgs e)
        {
            if (this.mainTableCombobox.SelectedIndex < 0)
            {
                return;
            }
            this.buildQueryTabPage.Enabled = true;
            this.mainTableTextBox.Text = this.mainTableCombobox.SelectedItem.ToString();
            this.joinQuery.mainTableName = this.mainTableCombobox.SelectedItem.ToString();
            this.SetCreateQueryDataGridView();
            this.joinQuery.queryName = this.queryNameTextBox.Text;
            this.createQueryTabControl.SelectedTab = this.buildQueryTabPage;
        }

        private void SetCreateQueryDataGridView()
        {
            buildQueryDataGridView.DataSource = new DataTable();
            List<string> joinTypesOptions = new List<string>(new string[] { "INNER JOIN", "JOIN", "OUTER JOIN", "LEFT JOIN", "RIGHT JOIN" });
            CreateComboBoxColumn("Join Type", joinTypesOptions);

            CreateComboBoxColumn("Table 1", this.joinQuery.database.tablesNames);
            CreateComboBoxColumn("Column 1", null);
            CreateComboBoxColumn("Table 2", this.joinQuery.database.tablesNames);
            CreateComboBoxColumn("Column 2", null);
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
                buildQueryDataGridView.Columns.Add(column);
            }
        }

        private void GoBackToMainTableTabFromBuildQueryTabButton_Click(object sender, EventArgs e)
        {
            this.createQueryTabControl.SelectedTab = this.mainTableTabPage;
        }

        private void GoToSelectColumnsTabFromBuildQueryTabButton_Click(object sender, EventArgs e)
        {
            this.selectColumnsTabPage.Enabled = true;
            this.createQueryTabControl.SelectedTab = this.selectColumnsTabPage;
            SetSelectColumnsDataFridView();
        }

        private void SetSelectColumnsDataFridView()
        {
            DataTable joinQueryDataTable = UIHelper.CreateDataTableFromDataGridView(buildQueryDataGridView);
            this.joinQuery.dataTable = joinQueryDataTable;
            List<string> tables = Helper.SelectOneColumnFromDataTable(joinQueryDataTable, "Table 1");
            tables.AddRange(Helper.SelectOneColumnFromDataTable(joinQueryDataTable, "Table 2"));
            List<string> columns = Helper.GetColumnsFromTables(Helper.ConvertListToSet(tables), this.joinQuery.database);
            DataTable datatableColumns = Helper.ConvertListToDataTable(columns);
            datatableColumns.Columns["Column1"].ColumnName = "Column Name";
            datatableColumns.Columns["Column Name"].ReadOnly = true;
            datatableColumns = Helper.DuplicateDatatableColumnWithValues(datatableColumns, "Column Name", "AS");
            selectColumnsDataGridView.AllowUserToAddRows = false;
            this.CreateCheckBoxColumn();
            selectColumnsDataGridView.DataSource = datatableColumns;
            selectColumnsDataGridView.Columns[1].Width = 200;
            selectColumnsDataGridView.Columns[2].Width = 200;

        }

        private void CreateCheckBoxColumn()
        {
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "";
            checkColumn.HeaderText = "";
            checkColumn.Width = 50;
            checkColumn.ReadOnly = false;
            checkColumn.FillWeight = 10;
            checkColumn.ValueType = typeof(bool);
            selectColumnsDataGridView.Columns.Add(checkColumn);
        }

        private void BuildQueryDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 3)
            {
                try
                {
                    int index = e.ColumnIndex;
                    DataGridViewRow row = this.buildQueryDataGridView.Rows[e.RowIndex];
                    string tableName = row.Cells[index].Value.ToString();
                    Database database = joinQuery.database;
                    if (tableName != "" && tableName != null)
                    {
                        List<string> columns = database.GetColumnsForTable(tableName);
                        DataGridViewComboBoxCell column1Cell = (DataGridViewComboBoxCell)row.Cells[index + 1];
                        column1Cell.DataSource = columns;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void GoToPreviewTabFromSelectColumnsTabButton_Click(object sender, EventArgs e)
        {
            this.SetJoinQuery();
            this.queryPreviewTabPage.Enabled = true;
            this.createQueryTabControl.SelectedTab = this.queryPreviewTabPage;
            this.queryRichTextBox.Text = this.joinQuery.query;
        }

        private void SetJoinQuery()
        {
            foreach (DataGridViewRow row in selectColumnsDataGridView.Rows)
            {
                if (row.Cells[0].Value == null || (bool)row.Cells[0].Value != true)
                {
                    row.Cells[0].Value = false;
                }
            }
            DataTable selectedColumnsDatatable = UIHelper.CreateDataTableFromDataGridView(selectColumnsDataGridView);
            JoinQuery.SetSelectedColumnsList(selectedColumnsDatatable, this.joinQuery);
            this.joinQuery.CreateAndSetJoinQuery();
        }

        private void GoBackToBuildQueryTabFromSelectColumnsTabButton_Click(object sender, EventArgs e)
        {
            this.createQueryTabControl.SelectedTab = this.buildQueryTabPage;
        }

        private void GoBackToSelectColumnsTabFromPreviewTabButton_Click(object sender, EventArgs e)
        {
            this.createQueryTabControl.SelectedTab = this.selectColumnsTabPage;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            bool queryIsValid = this.joinQuery.database.TrySelect(this.joinQuery.query.Insert(this.joinQuery.query.Length - 1, " WHERE 1=0"));
            if (queryIsValid)
            {
                string query = this.joinQuery.query;
                this.joinQuery.database.queries.Add(this.joinQuery);
                List<string> queriesNames = this.joinQuery.database.GetQueriesNames();
                this.joinQuery.database.queriesNames = queriesNames;
                TreeView treeview = ETLParent.GetTreeView();
                var result = treeview.Nodes.OfType<TreeNode>()
                                            .FirstOrDefault(node => node.Tag.Equals(this.joinQuery.database.databaseName));
                result.Nodes[1].Nodes.Clear();
                UIHelper.AddChildrenNodes(this.joinQuery.database.queriesNames, result.Nodes[1]);
                this.Close();
            }
            else
            {
                MessageBox.Show("Query is not valid. Please go back to previous steps and fix it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
