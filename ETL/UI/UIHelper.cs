using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETL.UI
{
    static class UIHelper
    {
        public static TreeNode AddBranch(string nodeName, TreeView treeView)
        {
            treeView.BeginUpdate();
            TreeNode treeNodeCreated = treeView.Nodes.Add(nodeName);
            treeView.EndUpdate();
            return treeNodeCreated;
        }

        public static void AddChildrenNodes(List<string> childrenNames, TreeNode parentNode)
        {
            if (parentNode != null)
            {
                foreach (string childName in childrenNames)
                {
                    parentNode.Nodes.Add(childName);
                }
            }
        }

        public static TreeNode AddChildBranch(string childNodeName, int parentIndex, TreeView treeView)
        {
            treeView.BeginUpdate();
            TreeNode treeNodeCreated = treeView.Nodes[parentIndex].Nodes.Add(childNodeName);
            treeView.EndUpdate();
            return treeNodeCreated;
        }

        public static DataTable CreateDataTableFromDataGridView(DataGridView dataGridView)
        {
            DataTable dt = new DataTable();

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value != "")
                    {
                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                    } 
                }
            }
            return dt;
        }
    }
}
