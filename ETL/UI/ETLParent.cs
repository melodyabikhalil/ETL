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

        private ProgressForm progressForm;
        private JobETL job;

        public ETLParent()
        {
            InitializeComponent();
            CenterToScreen();
            _instance = this;
            this.mainSplitContainer.Visible = false;
            this.AddMenuItems();
            JsonHelper.CreateJsonFolder();

            foreach (Database database in Global.Databases)
            {
                NewDatabaseForm.AddNodesToTreeView(database);
            }
            if (Global.Databases.Count > 0)
            {
                ShowMainContainer();
            }
            ETLParent.ReloadEtlsListInMenu();
            ETLParent.ReloadEtlJobsListInMenu();
        }

        private void AddMenuItems()
        {
            newQueryMenu.MenuItems.Add(newQueryMenuItem);
            newQueryMenuItem.Click += new EventHandler(newQueryMenuItem_Click);
            closeDatabaseMenu.MenuItems.Add(closeDatabaseMenuItem);
            closeDatabaseMenuItem.Click += new EventHandler(closeDatabaseMenuItem_Click);
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

        private void DatabasesTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level > 0 && e.Node.Parent.Text == "Queries")
            {
                string databaseName = e.Node.Parent.Parent.Text;
                Database database = Global.GetDatabaseByName(databaseName);
                JoinQuery query = database.GetQuery(e.Node.Text);
                ViewQueryForm viewQueryForm = new ViewQueryForm(query.GetName(), query.query);
                viewQueryForm.Show();
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
            CreateETLForm newEtlForm = new CreateETLForm();
            newEtlForm.TopLevel = false;
            this.mainSplitContainer.Panel2.Controls.Add(newEtlForm);
            newEtlForm.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            newEtlForm.Dock = DockStyle.Fill;
            newEtlForm.Show();
        }

        public static void ReloadEtlJobsListInMenu()
        {
            _instance.RunToolStripMenuItem.DropDownItems.Clear();
            foreach (JobETL job in Global.jobETLs)
            {
                ToolStripItem jobSubITem = new ToolStripMenuItem(job.name);
                jobSubITem.Click += new EventHandler(_instance.JobMenuItem_Click);
                _instance.RunToolStripMenuItem.DropDownItems.Add(jobSubITem);
            }
        }

        public static void ReloadEtlsListInMenu()
        {
            _instance.viewEditToolStripMenuItem.DropDownItems.Clear();
            foreach (SingleETL etl in Global.etls)
            {
                ToolStripItem etlSubItem = new ToolStripMenuItem(etl.name);
                etlSubItem.Click += new EventHandler(_instance.ViewEtlMenuItem_Click);
                _instance.viewEditToolStripMenuItem.DropDownItems.Add(etlSubItem);
            }
        }

        private void CreateJobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateJobForm createETLJob = new CreateJobForm();
            createETLJob.TopLevel = false;
            this.mainSplitContainer.Panel2.Controls.Add(createETLJob);
            createETLJob.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            createETLJob.Dock = DockStyle.Fill;
            createETLJob.Show();
        }

        void JobMenuItem_Click(object sender, EventArgs e)
        {
            string jobName = sender.ToString();
            JobETL job = Global.GetJobByName(jobName);
            this.job = job;
            if (job != null)
            {
                var pressed = MessageBox.Show("Are you sure you want to run this job?", "Run job", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (pressed == DialogResult.Yes)
                {
                    progressForm = Global.ProgressForm;
                    progressForm.Show();
                    Task task = new Task(RunJob);
                    task.Start();
                }
            }
        }

        public void RunJob()
        {
            this.job.Run();
        }

        void ViewEtlMenuItem_Click(object sender, EventArgs e)
        {
            string etlName = sender.ToString();
            SingleETL etl = Global.GetETLByName(etlName);
            if (etl != null)
            {
                ViewEditETLForm viewEditETLForm = new ViewEditETLForm(etl);
                viewEditETLForm.ShowDialog();
            }
        }

        private void editMappingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapForm mapForm = new MapForm();
            mapForm.Show();
        }
        
    }
}
