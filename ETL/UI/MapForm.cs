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
        public MapForm()
        {
            InitializeComponent();
            this.bindingSource1.DataSource = Global.mapDt;
            this.mapDataGridView.DataSource = this.bindingSource1;
        }

        private void finishButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
