using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ETL.Core;
using System.Data;
using Npgsql;

namespace ETLTest
{
    [TestClass]
    public class UnitTestDatabase
    {
        [TestMethod]
        public void TestMySQLConnection()
        {
            MySQLDatabase database = new MySQLDatabase("localhost", "root", "", "test_fyp");
            bool connected = database.Connect();
            Assert.IsTrue(connected);

            bool closed = database.Close();
            Assert.IsTrue(closed);

            database.password = "wrong";
            connected = database.Connect();
            Assert.IsFalse(connected);
        }

        [TestMethod]
        public void TestMySQLFetchData()
        {
            MySQLDatabase database = new MySQLDatabase("localhost", "root", "", "test_fyp");
            database.Connect();
            database.tablesNames = database.GetTablesNames();
            database.Close();
            database.CreateTablesList(database.tablesNames);
            for (int j = 0; j < database.tablesNames.Count; ++j)
            {
                database.Connect();
                database.SetDatatableSchema(database.tablesNames[j]);
                database.Close();
            }

            Assert.AreEqual(database.tables.Count, 5);

            DataTable expectedDatatable = new DataTable();
            expectedDatatable.Columns.Add("id", typeof(int));
            expectedDatatable.Columns.Add("name", typeof(string));
            expectedDatatable.Rows.Add(1, "melody");
            expectedDatatable.Rows.Add(2, "john");

            database.Select("authors", TableOrQuery.TYPE_TABLE);
            DataTable fetchedTable = database.GetTable("authors").dataTable;
            for (int i = 0; i < fetchedTable.Rows.Count; i++)
            {
                for (int c = 0; c < fetchedTable.Columns.Count; c++)
                {
                    var fetchedValue = fetchedTable.Rows[i][c];
                    var expectedValue = expectedDatatable.Rows[i][c];
                    Assert.AreEqual(fetchedValue, expectedValue);
                }
            }
        }

        [TestMethod]
        public void TestSQLServerConnection()
        {
            SQLServerDatabase database = new SQLServerDatabase("DESKTOP-NRFDC57\\MSSQLSERVER2", "sa", "P@ssw0rd", "Test", "dbo");
            bool connected = database.Connect();
            Assert.IsTrue(connected);

            bool closed = database.Close();
            Assert.IsTrue(closed);

            database.password = "wrong";
            connected = database.Connect();
            Assert.IsFalse(connected);
        }

        [TestMethod]
        public void TestSQLServerFetchData()
        {
            SQLServerDatabase database = new SQLServerDatabase("DESKTOP-NRFDC57\\MSSQLSERVER2", "sa", "P@ssw0rd", "Test", "dbo");
            database.Connect();
            database.tablesNames = database.GetTablesNames();
            database.Close();
            database.CreateTablesList(database.tablesNames);
            for (int j = 0; j < database.tablesNames.Count; ++j)
            {
                database.Connect();
                database.SetDatatableSchema(database.tablesNames[j]);
                database.Close();
            }

            Assert.AreEqual(database.tables.Count, 5);

            DataTable expectedDatatable = new DataTable();
            expectedDatatable.Columns.Add("id", typeof(int));
            expectedDatatable.Columns.Add("name", typeof(string));
            expectedDatatable.Columns.Add("dob", typeof(DateTime));
            expectedDatatable.Rows.Add(1, "melod     ", "2020-04-03 18:36:50.617");

            database.Select("Authors", TableOrQuery.TYPE_TABLE);
            DataTable fetchedTable = database.GetTable("Authors").dataTable;
            for (int i = 0; i < fetchedTable.Rows.Count; i++)
            {
                for (int c = 0; c < fetchedTable.Columns.Count; c++)
                {
                    var fetchedValue = fetchedTable.Rows[i][c];
                    var expectedValue = expectedDatatable.Rows[i][c];
                    Assert.AreEqual(fetchedValue, expectedValue);
                }
            }
        }

        [TestMethod]
        public void TestPostgreSQLConnection()
        {
            PostgreSQLDatabase database = new PostgreSQLDatabase("localhost", "postgres", "password", "postgres", "5432", "public");
            bool connected = database.Connect();
            Assert.IsTrue(connected);

            bool closed = database.Close();
            Assert.IsTrue(closed);

            database.password = "wrong";
            connected = database.Connect();
            Assert.IsFalse(connected);
        }

        [TestMethod]
        public void TestPostgreSQLFetchData()
        {
            PostgreSQLDatabase database = new PostgreSQLDatabase("localhost", "postgres", "password", "postgres", "5432", "public");
            database.Connect();
            database.tablesNames = database.GetTablesNames();
            database.Close();
            database.CreateTablesList(database.tablesNames);
            for (int j = 0; j < database.tablesNames.Count; ++j)
            {
                database.Connect();
                database.SetDatatableSchema(database.tablesNames[j]);
                database.Close();
            }

            Assert.AreEqual(database.tables.Count, 5);

            DataTable expectedDatatable = new DataTable();
            expectedDatatable.Columns.Add("id", typeof(int));
            expectedDatatable.Columns.Add("name", typeof(string));
            expectedDatatable.Rows.Add(3, "soumaya");

            database.Select("Users", TableOrQuery.TYPE_TABLE);
            DataTable fetchedTable = database.GetTable("Users").dataTable;
            for (int i = 0; i < fetchedTable.Rows.Count; i++)
            {
                for (int c = 0; c < fetchedTable.Columns.Count; c++)
                {
                    var fetchedValue = fetchedTable.Rows[i][c];
                    var expectedValue = expectedDatatable.Rows[i][c];
                    Assert.AreEqual(fetchedValue, expectedValue);
                }
            }
        }

        [TestMethod]
        public void TestAccessConnection()
        {
            AccessDatabase database = new AccessDatabase("C:\\Users\\Melody\\Documents\\Database2.mdb");
            bool connected = database.Connect();
            Assert.IsTrue(connected);

            bool closed = database.Close();
            Assert.IsTrue(closed);

            database.path = "wrong";
            connected = database.Connect();
            Assert.IsFalse(connected);
        }

        [TestMethod]
        public void TestAccessFetchData()
        {
            AccessDatabase database = new AccessDatabase("C:\\Users\\Melody\\Documents\\Database2.mdb");
            database.Connect();
            database.tablesNames = database.GetTablesNames();
            database.Close();
            database.CreateTablesList(database.tablesNames);
            for (int j = 0; j < database.tablesNames.Count; ++j)
            {
                database.Connect();
                database.SetDatatableSchema(database.tablesNames[j]);
                database.Close();
            }

            Assert.AreEqual(database.tables.Count, 3);

            DataTable expectedDatatable = new DataTable();
            expectedDatatable.Columns.Add("id", typeof(int));
            expectedDatatable.Columns.Add("name", typeof(string));
            expectedDatatable.Columns.Add("password", typeof(string));
            expectedDatatable.Columns.Add("age", typeof(string));
            expectedDatatable.Rows.Add(1, "Melody", "pass1", "22");
            expectedDatatable.Rows.Add(2, "Soumaya", "pass2", "22");

            database.Select("Users", TableOrQuery.TYPE_TABLE);
            DataTable fetchedTable = database.GetTable("Users").dataTable;
            for (int i = 0; i < fetchedTable.Rows.Count; i++)
            {
                for (int c = 0; c < fetchedTable.Columns.Count; c++)
                {
                    var fetchedValue = fetchedTable.Rows[i][c];
                    var expectedValue = expectedDatatable.Rows[i][c];
                    Assert.AreEqual(fetchedValue, expectedValue);
                }
            }
        }
    }
}
