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
            // Hide the tabs headers
            this.newDatabaseTabControl.Appearance = TabAppearance.FlatButtons;
            this.newDatabaseTabControl.ItemSize = new Size(0, 1);
            this.newDatabaseTabControl.SizeMode = TabSizeMode.Fixed;

            this.CenterToParent();
            this.credentialsTabPage.Enabled = false;
            this.AcceptButton = connectButton;
            this.dbTypesComboBox.Items.Add(Database.DATABASE_TYPE_MYSQL);
            this.dbTypesComboBox.Items.Add(Database.DATABASE_TYPE_SQLSERVER);
            this.dbTypesComboBox.Items.Add(Database.DATABASE_TYPE_POSTGRES);
            this.dbTypesComboBox.Items.Add(Database.DATABASE_TYPE_ACCESS);
            this.dbTypesComboBox.Items.Add(Database.DATABASE_TYPE_ODBC);
        }

        private void ConnectToDb(string dbType)
        {
            Database database;
            switch (dbType)
            {
                case Database.DATABASE_TYPE_MYSQL:
                    database = this.CreateMysqlDatabase();
                    break;
                case Database.DATABASE_TYPE_SQLSERVER:
                    database = this.CreateSQLServerDatabase();
                    break;
                case Database.DATABASE_TYPE_POSTGRES:
                    database = this.CreatePostgresDatabase();
                    break;
                case Database.DATABASE_TYPE_ACCESS:
                    database = this.CreateAccessDatabase();
                    break;
                case Database.DATABASE_TYPE_ODBC:
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
                database.GetQueriesNames();

                if (Global.DatabaseAlreadyConnected(database))
                {
                    this.ShowErrorDialogAndClose();
                }
                Global.Databases.Add(database);
                AddNodesToTreeView(database);

                bool rememberDatabase = rememberDatabaseCheckbox.Checked;
                if (rememberDatabase)
                {
                    JsonHelper.SaveDatabase(database, true);
                }

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

        private void ShowErrorDialogAndClose()
        {
            var okPressed = MessageBox.Show("Already connected to this database", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (okPressed == DialogResult.OK)
            {
                this.Close();
            }
        }

        public static void AddNodesToTreeView(Database database)
        {
            TreeView treeview = ETLParent.GetTreeView();
            TreeNode node = UIHelper.AddBranch(database.databaseName, treeview);
            node.Tag = database.databaseName;

            TreeNode tablesNode = UIHelper.AddChildBranch("Tables", node.Index, treeview);
            UIHelper.AddChildrenNodes(database.tablesNames, tablesNode);

            TreeNode queriesNode = UIHelper.AddChildBranch("Queries", node.Index, treeview);
            UIHelper.AddChildrenNodes(database.queriesNames, queriesNode);
        }

        private void GoToCredentialsTabFromTypeTabButton_Click(object sender, EventArgs e)
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

        private void GoBackToTypeTabFromCredentialsTabButton_Click(object sender, EventArgs e)
        {
            this.newDatabaseTabControl.SelectedTab = this.typeTabPage;
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            this.ConnectToDb(dbTypesComboBox.SelectedItem.ToString());
        }
    }
}
