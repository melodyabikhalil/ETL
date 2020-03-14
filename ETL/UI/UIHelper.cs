using System;
using System.Collections.Generic;
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
    }
}
