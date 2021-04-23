using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using System.Diagnostics;
using Interfaces.Interfaces;


namespace Application.Services
{
    public class IOKeepTableService
    {
        private List<TreeNode> TreeNodeList = new List<TreeNode>(); //Work data, skall hämtas från IOService senare.
        private TreeInitUtils TreeBuilderUtils = new TreeInitUtils();

        private IIOKeepTableDataAccess iIOKeepTableDataAccess;

        public IOKeepTableService(IIOKeepTableDataAccess _iIOKeepTableDataAccess)
        {
            iIOKeepTableDataAccess = _iIOKeepTableDataAccess;
        }


        public List<TreeNode> IOColumnNamesAsTreeNodes()
        {
            List<string> IONameList = iIOKeepTableDataAccess.IOColumnNames_FromIOKeepTable(); //Här skall det in anrop till IODataAccess, vilken inte är skapad ännu.
            IONameList.ToArray();
            TreeNodeList.Clear();
            TreeNodeList = TreeBuilderUtils.NameListToNameNodeList(IONameList);
            TreeNodeList = TreeBuilderUtils.InjectNodesInTreeAtLevel(TreeNodeList, 0);
            TreeNodeList = TreeBuilderUtils.InjectNodesInTreeAtLevel(TreeNodeList, 1);
            TreeNodeList = TreeBuilderUtils.InjectNodesInTreeAtLevel(TreeNodeList, 2);
            foreach (TreeNode t in TreeNodeList)
            {
                //Debug.WriteLine($"In IOColumnNamesAsTreeNodes: {t.Name}");
            }
            return TreeNodeList;
        }
    }
}
