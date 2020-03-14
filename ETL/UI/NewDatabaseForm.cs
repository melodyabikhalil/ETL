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
    public partial class NewDatabaseForm : Form
    {
        public NewDatabaseForm()
        {
            InitializeComponent();
            this.CenterToParent();
            this.typeTabPage.Enabled = false;
            this.credentialsTabPage.Enabled = false;
            this.AcceptButton = Connect;
        }

        private void connectToDb(int dbType, bool isSource)
        {
            Database database;
            switch (dbType)
            {
                case 0:
                    database = this.CreateMysqlDatabase();
                    break;
                case 1:
                    database = this.CreateSQLServerDatabase();
                    break;
                case 2:
                    database = this.CreatePostgresDatabase();
                    break;
                case 3:
                    database = this.CreateAccessDatabase();
                    break;
                case 4:
                    database = this.CreateODBCDatabase();
                    break;
                default:
                    database = this.CreateMysqlDatabase();
                    break;
            }
            bool connected = database.Connect();
            if (connected)
            {
                database.tablesNames = database.GetTablesNames();
                database.CreateTablesList(database.tablesNames);
                if (Global.DatabaseAlreadyConnected(database))
                {
                    this.ShowErrorDialogAndClose();
                }
                Global.Databases.Add(database);
                this.AddNodesToTreeView(isSource, database);
                ETLParent.ShowMainContainer();
                this.Close();
            }
            else
            {
                var pressed = MessageBox.Show("Could not connect to database", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (pressed == DialogResult.Cancel)
                {
                    this.Close();
                }
            }

        }

        private MySQLDatabase CreateMysqlDatabase()
        {
            string databaseName = dbNameTextBox.Text;
            string username = usernameTextBox.Text;
            string password = passTextBox.Text;
            string serverName = hostTextBox.Text;
            MySQLDatabase mySQLDatabase = new MySQLDatabase(serverName, username, password, databaseName);
            return mySQLDatabase;
        }

        private PostgreSQLDatabase CreatePostgresDatabase()
        {
            string databaseName = dbNameTextBox.Text;
            string username = usernameTextBox.Text;
            string password = passTextBox.Text;
            string serverName = hostTextBox.Text;
            string schema = schemaTextBox.Text;
            string port = portTextBox.Text;
            PostgreSQLDatabase postgreSQLDatabase = new PostgreSQLDatabase(serverName, username, password, databaseName, port, schema);
            return postgreSQLDatabase;
        }

        private SQLServerDatabase CreateSQLServerDatabase()
        {
            string databaseName = dbNameTextBox.Text;
            string username = usernameTextBox.Text;
            string password = passTextBox.Text;
            string serverName = hostTextBox.Text;
            string schema = schemaTextBox.Text;
            SQLServerDatabase sqlServerDatabase = new SQLServerDatabase(serverName, username, password, databaseName, schema);
            return sqlServerDatabase;
        }

        private AccessDatabase CreateAccessDatabase()
        {
            string path = dbNameTextBox.Text;
            AccessDatabase accessDatabase = new AccessDatabase(path);
            return accessDatabase;
        }

        private Database CreateODBCDatabase()
        {
            string connectionString = dbNameTextBox.Text;
            ODBCDatabase odbcDatabase = new ODBCDatabase(connectionString);
            return odbcDatabase;
        }

        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;
            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };
            func(Controls);
        }

        private void ShowErrorDialogAndClose()
        {
            var okPressed = MessageBox.Show("Already connected to this database", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (okPressed == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void AddNodesToTreeView(bool isSource, Database database)
        {
            TreeView treeview = ETLParent.GetTreeView();
            TreeNode node = ETLParent.AddBranch(database.databaseName, treeview);
            // TODO: add Tables & Queries nodes 
            ETLParent.AddChildrenNodes(database.tablesNames, node.Index, treeview);
        }

        private void SrcDestNex_Click(object sender, EventArgs e)
        {
            this.typeTabPage.Enabled = true;
            this.newDatabaseTabControl.SelectedTab = this.typeTabPage;
        }

        private void backToSrcDest_Click(object sender, EventArgs e)
        {
            this.newDatabaseTabControl.SelectedTab = this.sourceDestinationTabPage;
        }

        private void dbTypeButton_Click(object sender, EventArgs e)
        {
            this.credentialsTabPage.Enabled = true;
            this.newDatabaseTabControl.SelectedTab = this.credentialsTabPage;
            switch (this.dbTypesComboBox.SelectedIndex)
            {

                case 0:
                    schemaLabel.Hide();
                    schemaTextBox.Hide();
                    portLabel.Hide();
                    portTextBox.Hide();
                    hostTextBox.Show();
                    hostLabel.Show();
                    usernameTextBox.Show();
                    usernameLabel.Show();
                    passTextBox.Show();
                    passwordLabel.Show();
                    dbNameLabel.Show();
                    dbNameTextBox.Show();
                    break;
                case 1:
                    schemaLabel.Show();
                    schemaTextBox.Show();
                    portLabel.Hide();
                    portTextBox.Hide();
                    hostTextBox.Show();
                    hostLabel.Show();
                    usernameTextBox.Show();
                    usernameLabel.Show();
                    passTextBox.Show();
                    passwordLabel.Show();
                    dbNameLabel.Show();
                    dbNameTextBox.Show();
                    break;
                case 2:
                    schemaLabel.Show();
                    schemaTextBox.Show();
                    portLabel.Show();
                    portTextBox.Show();
                    hostTextBox.Show();
                    hostLabel.Show();
                    usernameTextBox.Show();
                    usernameLabel.Show();
                    passTextBox.Show();
                    passwordLabel.Show();
                    dbNameLabel.Show();
                    dbNameTextBox.Show();
                    break;
                case 3:
                    hostTextBox.Hide();
                    hostLabel.Hide();
                    usernameTextBox.Hide();
                    usernameLabel.Hide();
                    passTextBox.Hide();
                    passwordLabel.Hide();
                    dbNameLabel.Text = "Path";
                    dbNameTextBox.Show();
                    portLabel.Hide();
                    portTextBox.Hide();
                    schemaLabel.Hide();
                    schemaTextBox.Hide();
                    break;
                case 4:
                    hostTextBox.Hide();
                    hostLabel.Hide();
                    usernameTextBox.Hide();
                    usernameLabel.Hide();
                    passTextBox.Hide();
                    passwordLabel.Hide();
                    dbNameLabel.Text = "Connection String";
                    dbNameTextBox.Show();
                    portLabel.Hide();
                    portTextBox.Hide();
                    schemaLabel.Hide();
                    schemaTextBox.Hide();
                    break;
            }
        }

        private void backToDbTypes_Click(object sender, EventArgs e)
        {
            this.newDatabaseTabControl.SelectedTab = this.typeTabPage;
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            var checkedButton = this.sourceDestinationTabPage.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            bool isSource = checkedButton.Name == "srcRadioButton";
            this.connectToDb(dbTypesComboBox.SelectedIndex, isSource);
        }
    }
}
