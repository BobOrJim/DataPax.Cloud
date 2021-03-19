using Application.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    internal class TreeInitUtils
    {
        public List<TreeNode> TreeNodeList = new List<TreeNode>(); 
        public List<TreeNode> WorkTreeNodeList = new List<TreeNode>();

        //Create TreeNode list (leafs) from a string list.
        public List<TreeNode> NameListToNameNodeList(List<string> IONameList)
        {
            foreach (string s in IONameList)
            {
                TreeNode treeNode = new TreeNode()
                {
                    Name = s.ToString(),
                    Level = 3,
                    Id = 0,
                    PleaseExpand = false,
                    ToRenderInMarkup = false
                };
                TreeNodeList.Add(treeNode);
            }
            foreach (TreeNode t in TreeNodeList)
            {
                //Debug.WriteLine(t.Name);
            }
            return TreeNodeList;
        }

        //Inject/Create parent Nodes at the requested level
        public List<TreeNode> InjectNodesInTreeAtLevel(List<TreeNode> _treeNodeList, int _Level)
        {
            WorkTreeNodeList = _treeNodeList.ToList(); //Have to use a intermediate storage, to avoid pass by reference (?) fault with Clear below.
            TreeNodeList.Clear();
            //Debug.WriteLine($"Inuti InjectNodesInTreeAtLevel är TreeNodeList.Count() inför level {_Level} = {WorkTreeNodeList.Count()} ");
            string LatestUniqueLevelNodeName = "__";
            string LevelName = "";
            foreach (TreeNode t in WorkTreeNodeList)
            {
                string[] Names = t.Name.Split('_'); //A child node always has 4 string parts, a non child node always has 1.
                //Debug.WriteLine($"Lenght = {Names.Length} ");
                if (Names.Length == 1)
                {
                    LevelName = "";
                }
                else
                {
                    LevelName = Names[_Level];
                }
                if (LevelName != LatestUniqueLevelNodeName && LevelName != "")
                {
                    TreeNode treeNode = new TreeNode()
                    {
                        Name = LevelName,
                        Level = _Level,
                        Id = 0,
                        PleaseExpand = false,
                        ToRenderInMarkup = false
                    };
                    TreeNodeList.Add(treeNode);
                    TreeNodeList.Add(t);
                }
                else
                {
                    TreeNodeList.Add(t);
                }
                LatestUniqueLevelNodeName = LevelName;
            }
            int i = 0;
            foreach (TreeNode treeNode in TreeNodeList)
            {
                treeNode.Id = i;
                i++;
                if (treeNode.Level == 0)
                {
                    treeNode.ToRenderInMarkup = true;
                }
            }
            //Debug.WriteLine($"__________________Antalet noder i TreeNodeList.Count() = {TreeNodeList.Count()} ");
            return TreeNodeList;
        }
    }
}





/*
IONameList.Add("Line 1_Machine 1_IO group 1_IO A");
IONameList.Add("Line 1_Machine 1_IO group 1_IO B");
IONameList.Add("Line 1_Machine 1_IO group 2_IO C");
IONameList.Add("Line 1_Machine 1_IO group 2_IO D");
IONameList.Add("Line 1_Machine 2_IO group 2_IO C");
IONameList.Add("Line 1_Machine 2_IO group 2_IO D");
IONameList.Add("Line 2_Machine 2_IO group 2_IO C");
IONameList.Add("Line 2_Machine 2_IO group 2_IO D");
IONameList.Add("Line 2_Machine 3_IO group 2_IO C");
IONameList.Add("Line 2_Machine 3_IO group 2_IO D");
*/


/*
Line 1
Machine 1
IO group 1
Line 1_Machine 1_IO group 1_IO A
Line 1_Machine 1_IO group 1_IO B
IO group 2
Line 1_Machine 1_IO group 2_IO C
Line 1_Machine 1_IO group 2_IO D
Machine 2
IO group 2
Line 1_Machine 2_IO group 2_IO C
Line 1_Machine 2_IO group 2_IO D
Line 2
Machine 2
IO group 2
Line 2_Machine 2_IO group 2_IO C
Line 2_Machine 2_IO group 2_IO D
Machine 3
IO group 2
Line 2_Machine 3_IO group 2_IO C
IO group 3
Line 2_Machine 3_IO group 3_IO D
*/