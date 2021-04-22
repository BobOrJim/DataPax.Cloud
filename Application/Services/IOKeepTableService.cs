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
        private List<string> IONameList = new List<string>();
        private string[] IONameArray;

        private IIOKeepTableDataAccess iIOKeepTableDataAccess;

        public IOKeepTableService(IIOKeepTableDataAccess _iIOKeepTableDataAccess)
        {
            iIOKeepTableDataAccess = _iIOKeepTableDataAccess;
        }


        private void ReadIOColumnsFromDB()
        {
            IONameList = myMoqColumn(); //Här skall det in anrop till IODataAccess, vilken inte är skapad ännu.
            IONameArray = IONameList.ToArray();
        }



        public List<TreeNode> IOColumnNamesAsTreeNodes()
        {
            ReadIOColumnsFromDB();
            TreeNodeList.Clear();
            TreeNodeList = TreeBuilderUtils.NameListToNameNodeList(IONameList);
            TreeNodeList = TreeBuilderUtils.InjectNodesInTreeAtLevel(TreeNodeList, 0);
            TreeNodeList = TreeBuilderUtils.InjectNodesInTreeAtLevel(TreeNodeList, 1);
            TreeNodeList = TreeBuilderUtils.InjectNodesInTreeAtLevel(TreeNodeList, 2);
            foreach (TreeNode t in TreeNodeList)
            {
                Debug.WriteLine(t.Name);
            }
            return TreeNodeList;
        }



        //NOTERING: Detta är kolumn namn. Jag kommer ha två alternativ framöver:
        //1: Försöka plocka ur kolumnnamnen från EF
        //2: Hårdkoda modell, (samma som för picture, dvs kolumn blir en Model. Jag skall välja den lätta tills Docker grejen är färdig.
        public List<string> myMoqColumn()
        {
            //Obs, underscore är radbrytare, inte mellanslag. Dvs det är fyra kategorier.
            List<string> tmpList = new List<string>();
            tmpList.Clear();
            tmpList.Add("Line 1_Machine 1_IO group 1_IO A");
            tmpList.Add("Line 1_Machine 1_IO group 1_IO B");
            tmpList.Add("Line 1_Machine 1_IO group 2_IO C");
            tmpList.Add("Line 1_Machine 1_IO group 2_IO D");
            tmpList.Add("Line 1_Machine 2_IO group 2_IO C");
            tmpList.Add("Line 1_Machine 2_IO group 2_IO D");
            tmpList.Add("Line 2_Machine 2_IO group 2_IO C");
            tmpList.Add("Line 2_Machine 2_IO group 2_IO D");
            tmpList.Add("Line 2_Machine 3_IO group 2_IO C");
            tmpList.Add("Line 2_Machine 3_IO group 3_IO D");
            return tmpList;
        }


    }
}
