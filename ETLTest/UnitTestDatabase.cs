using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ETL.Core;
using System.Data;

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
    }
}
