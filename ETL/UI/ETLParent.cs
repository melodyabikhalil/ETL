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
        private static ETLParent _instance;
        MenuItem newQueryMenuItem = new MenuItem("Add query");
        MenuItem closeDatabaseMenuItem = new MenuItem("Remove");
        ContextMenu newQueryMenu = new ContextMenu();
        ContextMenu closeDatabaseMenu = new ContextMenu();
        string databaseToClose = "";
        JoinQuery joinQuery;

        public ETLParent()
        {
            InitializeComponent();
            CenterToScreen();
            _instance = this;
            this.mainSplitContainer.Visible = false;
            newQueryMenu.MenuItems.Add(newQueryMenuItem);
            newQueryMenuItem.Click += new EventHandler(newQueryMenuItem_Click);
            closeDatabaseMenu.MenuItems.Add(closeDatabaseMenuItem);
            closeDatabaseMenuItem.Click += new EventHandler(closeDatabaseMenuItem_Click);
            JsonHelper.CreateJsonFolder();
            this.LoadSavedDataFromJsonFiles();
        }

        private void LoadSavedDataFromJsonFiles()
        {
            this.LoadDatabasesFromJsonFile();
            this.LoadEtlsFromJsonFile();
            this.LoadEtlJobsFromJsonFile();
        }

        private void LoadDatabasesFromJsonFile()
        {
            List<Database> databases = JsonHelper.GetDatabasesFromJsonFile();
            foreach (Database database in databases)
            {
                bool canConnect = database.Connect();
                database.Close();
                if (canConnect)
                {
                    if (!Global.DatabaseAlreadyConnected(database))
                    {
                        NewDatabaseForm.AddNodesToTreeView(database);
                        Global.Databases.Add(database);
                    }
                    if (databases.Count > 0)
                    {
                        ShowMainContainer();
                    }
                }
            }
        }

        private void LoadEtlsFromJsonFile()
        {
            List<SingleETL> etls = JsonHelper.GetETLsFromJsonFile();
            Global.etls = etls;
        }

        private void LoadEtlJobsFromJsonFile()
        {
            List<JobETL> jobs = JsonHelper.GetETLJobsFromJsonFile();
            Global.jobETLs = jobs;
            ETLParent.ReloadEtlJobsListInMenu();
        }

        private void ETLParent_Activated(object sender, EventArgs e)
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
            if (e.Node.Level == 0 && e.Button == MouseButtons.Right)
            {
                closeDatabaseMenu.Show(databasesTreeView, e.Location);
                string databaseName = e.Node.Text;
                this.databaseToClose = databaseName;
            }
        }

        void newQueryMenuItem_Click(object sender, EventArgs e)
        {
            CreateQueryForm createQueryForm = new CreateQueryForm();
            createQueryForm.SetJoinQuery(this.joinQuery);
            createQueryForm.TopLevel = false;
            this.mainSplitContainer.Panel2.Controls.Add(createQueryForm);
            createQueryForm.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            createQueryForm.Dock = DockStyle.Fill;
            createQueryForm.Show();
        }

        void closeDatabaseMenuItem_Click(object sender, EventArgs e)
        {
            Database database = Global.GetDatabaseByName(this.databaseToClose);
            if (database != null)
            {
                Global.Databases.Remove(database);
                var result = databasesTreeView.Nodes.OfType<TreeNode>()
                                        .FirstOrDefault(node => node.Tag.Equals(database.databaseName));
                this.databasesTreeView.Nodes.Remove(result);
            }
        }

        private void createStripMenuItem_Click(object sender, EventArgs e)
        {
            NewETLForm newEtlForm = new NewETLForm();
            newEtlForm.TopLevel = false;
            this.mainSplitContainer.Panel2.Controls.Add(newEtlForm);
            newEtlForm.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            newEtlForm.Dock = DockStyle.Fill;
            newEtlForm.Show();
        }

        public static void ReloadEtlJobsListInMenu()
        {
            foreach (JobETL job in Global.jobETLs)
            {
                ToolStripItem jobSubITem = new ToolStripMenuItem(job.name);
                _instance.RunToolStripMenuItem.DropDownItems.Add(jobSubITem);
            }
        }

        private void CreateJobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateETLJob createETLJob = new CreateETLJob();
            createETLJob.TopLevel = false;
            this.mainSplitContainer.Panel2.Controls.Add(createETLJob);
            createETLJob.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            createETLJob.Dock = DockStyle.Fill;
            createETLJob.Show();
        }
    }
}
