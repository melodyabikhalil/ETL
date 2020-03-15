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
    public partial class ETLParent : Form
    {
        private int childFormNumber = 0;
        private static ETLParent _instance;
        MenuItem newQueryMenuItem = new MenuItem("Add query");
        ContextMenu newQueryMenu = new ContextMenu();
        JoinQuery joinQuery;

        public ETLParent()
        {
            InitializeComponent();
            CenterToScreen();
            _instance = this;
            this.mainSplitContainer.Visible = false;
            newQueryMenu.MenuItems.Add(newQueryMenuItem);
            newQueryMenuItem.Click += new EventHandler(newQueryMenuItem_Click);
        }

        private void ETLParent_Activated(object sender, System.EventArgs e)
        {
            MessageBox.Show("activated:");
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            NewDatabaseForm newDatabaseForm = new NewDatabaseForm();
            newDatabaseForm.ShowDialog();
        }

        public static TreeView GetTreeView()
        {
            return _instance.databasesTreeView;
        }

        public static void ShowMainContainer()
        {
            _instance.mainSplitContainer.Visible = true;
        }

        private void DatabasesTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1 && e.Node.Text == "Queries" && e.Button == MouseButtons.Right)
            {
                string databaseName = e.Node.Parent.Text;
                Database database = Global.GetDatabaseByName(databaseName);
                this.joinQuery = new JoinQuery();
                this.joinQuery.database = database;
                newQueryMenu.Show(databasesTreeView, e.Location);
            }
            
        }

        void newQueryMenuItem_Click(object sender, EventArgs e)
        {
            CreateQueryForm createQueryForm = new CreateQueryForm();
            createQueryForm.SetJoinQuery(this.joinQuery);
            createQueryForm.TopLevel = false;
            this.mainSplitContainer.Panel2.Controls.Add(createQueryForm);
            createQueryForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            createQueryForm.Dock = DockStyle.Fill;
            createQueryForm.Show();
        }
    }
}
