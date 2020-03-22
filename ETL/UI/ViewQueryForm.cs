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
        public ViewQueryForm(string queryName, string query)
        {
            InitializeComponent();
            this.queryNameLabel.Text += "\t" + queryName;
            this.queryLabel.Text +=  "\n\n\t" + query;
            CenterToParent();
        }


        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
