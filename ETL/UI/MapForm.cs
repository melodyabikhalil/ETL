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
    public partial class MapForm : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        public bool changed { get; set; }
        public MapForm()
        {
            InitializeComponent();
            this.bindingSource1.DataSource = Global.mapDt;
            this.mapDataGridView.DataSource = this.bindingSource1;
            this.changed = false;
        }

        private void removeEmptyRows()
        {
            bool Empty = true;

            for (int i = 0; i < this.mapDataGridView.Rows.Count - 1; i++)
            {
                Empty = true;
                for (int j = 0; j < this.mapDataGridView.Columns.Count; j++)
                {
                    if (this.mapDataGridView.Rows[i].Cells[j].Value != null && this.mapDataGridView.Rows[i].Cells[j].Value.ToString() != "")
                    {
                        Empty = false;
                        break;
                    }
                }
                if (Empty)
                {
                    if (this.mapDataGridView.Rows[i].IsNewRow)
                    {
                        Global.mapDt.Rows[i].RejectChanges();
                    }
                    else
                    {
                        this.mapDataGridView.Rows.RemoveAt(i);
                    }
                }
            }
        }

        private void finishButton_Click(object sender, EventArgs e)
        {
            removeEmptyRows();
            if (changed)
            {
                MessageBox.Show("Map successfully edited", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            JsonHelper.SaveMapDt(Global.mapDt);
            this.Close();
        }

        private void mapDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
                this.changed = true;
        }
    }
        
   
}
