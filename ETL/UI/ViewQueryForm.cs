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
    public partial class ViewQueryForm : Form
    {
        public ViewQueryForm(string queryName, string queryMainTable, string query)
        {
            InitializeComponent();
            this.queryNameLabel.Text = this.queryNameLabel.Text + " " + queryName;
            this.queryMainTableLabel.Text = this.queryMainTableLabel.Text + " " + queryMainTable;
            this.queryLabel.Text = this.queryLabel.Text + " " + query;
        }


        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
