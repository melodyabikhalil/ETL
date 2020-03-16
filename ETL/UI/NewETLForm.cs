﻿using ETL.Core;
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
        private SourceTableOrQuery srcTable;
        private Table destTable;
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

        private void fromETLNameToSrcDrstDbButton_Click(object sender, EventArgs e)
        {
            this.SrcDestDbTab.Enabled = true;
            this.ETLTabControl.SelectedTab = this.SrcDestDbTab;
        }

        private void backFromSrcDestDbToETLNameButton_Click(object sender, EventArgs e)
        {
            this.ETLTabControl.SelectedTab = this.ETLNameTab;
        }

        private void fromSrcDestDbToSrcDestTablesButton_Click(object sender, EventArgs e)
        {
            string srcDatabase = this.sourceDbComboBox.Text;
            string destDatabase = this.destinationDbComboBox.Text;
            src = Global.GetDatabaseByName(srcDatabase);
            dest = Global.GetDatabaseByName(destDatabase);
            for(int i = 0; i< src.tablesNames.Count; ++i)
            {
                this.srcTableOrQueriesComboBox.Items.Insert(i, src.tablesNames[i]);
            }
            for (int i = src.tablesNames.Count; i < src.queriesNames.Count + src.tablesNames.Count; ++i)
            {
                this.srcTableOrQueriesComboBox.Items.Insert(i, src.queriesNames[i]);
            }
            for (int i = 0; i < dest.tablesNames.Count; ++i)
            {
                this.destTableComboBox.Items.Insert(i, dest.tablesNames[i]);
            }
            this.SrcDestTablesTab.Enabled = true;
            this.ETLTabControl.SelectedTab = this.SrcDestTablesTab;
        }

        private void setExpressionDataGridView()
        {
            string destTableName = this.destTableComboBox.Text;
            dest.Close();
            dest.SetDatatableSchema(destTableName);
            string srcTableName = this.srcTableOrQueriesComboBox.Text;
            src.Close();
            src.SetDatatableSchema(srcTableName);
            this.srcTable = Global.GetTableByNameAndDbName(this.sourceDbComboBox.Text, srcTableName);
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
            HashSet<string> secitons = Global.mapDt.AsEnumerable().Select(r => r.Field<string>("SectionName")).ToHashSet();
            List<string> sectionNames = new List<string>();
            foreach (string section in secitons)
            {
                sectionNames.Add(section);
            }
            CreateComboBoxColumn("Section Name", sectionNames, "SectionName");
        }

        private void fromSrcDestTablesToExpression_Click(object sender, EventArgs e)
        {
            setExpressionDataGridView();
            this.ExpressionTab.Enabled = true;
            this.ETLTabControl.SelectedTab = this.ExpressionTab;
        }

        private void backToSrcDestDbFromSrcDestTables_Click(object sender, EventArgs e)
        {
            this.ETLTabControl.SelectedTab = this.SrcDestDbTab;
        }

        private void CreateComboBoxColumn(string header, List<string> values, string name)
        {
            DataGridViewComboBoxColumn column =
                new DataGridViewComboBoxColumn();
            {
                column.Name = name;
                column.Width = 170;
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
                column.Width = 170;
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

        private void backToSrcDestTablesTabButton_Click(object sender, EventArgs e)
        {
            this.ETLTabControl.SelectedTab = this.SrcDestTablesTab;
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            ETLClass etl = new ETLClass(src, dest, srcTable, destTable, this.CreateExpressionDatatable());
            Global.etls.Add(etl);
            this.Close();
        }

        private void ExpressionDataGridView_RowsAdded(object sender, System.Windows.Forms.DataGridViewRowsAddedEventArgs e)
        {
            for (int index = e.RowIndex; index <= e.RowIndex + e.RowCount - 1; index++)
            {
                DataGridViewRow row = ExpressionDataGridView.Rows[index];
                row.Cells[0].Value = this.destTableComboBox.Text;
            }
        }
        
    }
}