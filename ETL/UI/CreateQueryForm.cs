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

namespace ETL.UI
{
    public partial class CreateQueryForm : Form
    {
        private JoinQuery joinQuery;
        private List<string> mainTableOptions = new List<string>();

        public CreateQueryForm()
        {
            InitializeComponent();
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
            this.SetCreateQueryDataGridView();
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

        private void SetTableOptionsForDatagridViewColumns(DataGridViewComboBoxColumn comboboxColumn, List<string> values)
        {
            comboboxColumn.Items.AddRange(values);
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
        }

        private List<string> GetColumnsForTable(string tableName, Database database)
        {
            List<string> columns = new List<string>();
            database.Connect();
            bool gotTableSchema = database.SetDatatableSchema(tableName);
            database.Close();
            if (!gotTableSchema)
            {
                return columns;
            }
            Table table = database.GetTable(tableName);
            columns = table.GetColumnsNames();
            return columns;
        }

        private void BuildQueryDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 3)
            {
                int index = e.ColumnIndex;
                DataGridViewRow row = this.buildQueryDataGridView.Rows[e.RowIndex];
                string tableName = row.Cells[index].Value.ToString();
                Database database = joinQuery.database;
                if (tableName != "" && tableName != null)
                {
                    List<string> columns = this.GetColumnsForTable(tableName, database);
                    DataGridViewComboBoxCell column1Cell = (DataGridViewComboBoxCell)row.Cells[index + 1];
                    column1Cell.DataSource = columns;
                }
            }
        }
    }
}
