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

        public List<XYValuePair> GetXYValuePairFromSignalBetween(string Signal, Int64 Start, Int64 Stop)
        {
            Debug.WriteLine($"in GetXYValuePairFromSignalBetween. Start = {Start} ");
            Debug.WriteLine($"in GetXYValuePairFromSignalBetween. Stop = {Stop} ");


            Int64[] XValueWorkList = iIOKeepTableDataAccess.IOXCoordinatesFromSignal_FromIOKeepTable(Signal).ToArray();
            Boolean[] YValueWorkList = iIOKeepTableDataAccess.IOYCoordinatesFromSignal_FromIOKeepTable(Signal).ToArray();
            Debug.WriteLine($"in GetXYValuePairFromSignalBetween. XValueWorkList.Length = {XValueWorkList.Length}");
            Debug.WriteLine($"in GetXYValuePairFromSignalBetween. YValueWorkList.Length = {YValueWorkList.Length}");

            List <XYValuePair> ReturnList = new List<XYValuePair>();
            for (int i = 0; i < XValueWorkList.Length; i++)
            {
                //Debug.WriteLine($"in GetXYValuePairFromSignalBetween in for loop. XValueWorkList[i] = {XValueWorkList[i]} start = {Start} stop = {Stop}");

                if (XValueWorkList[i] > Start && XValueWorkList[i] < Stop)
                {
                    XYValuePair tmp = new XYValuePair();
                    tmp.XCoordinateInt64 = XValueWorkList[i];
                    tmp.YCoordinateBoolean = YValueWorkList[i];
                    ReturnList.Add(tmp);
                }
            }
            Debug.WriteLine($"in GetXYValuePairFromSignalBetween. ReturnList.Count = {ReturnList.Count}");

            return ReturnList;
        }

        public List<Int64> GetXCordinatesBetween(string Signal, Int64 Start, Int64 Stop)
        {
            List<Int64> WorkList = iIOKeepTableDataAccess.IOXCoordinatesFromSignal_FromIOKeepTable(Signal);
            List<Int64> ReturnList = new List<Int64>();
            foreach (Int64 item in WorkList)
            {
                if (item > Start && item < Stop)
                {
                    ReturnList.Add(item);
                }
            }
            return ReturnList;
        }

        public List<Boolean> GetYCoordinatesFromSignalBetwenStartAndEnd(string Signal, Int64 Start, Int64 End)
        {
            return iIOKeepTableDataAccess.IOYCoordinatesFromSignal_FromIOKeepTable(Signal);
        }

    }
}
