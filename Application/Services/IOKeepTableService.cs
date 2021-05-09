using System;
using System.Collections.Generic;
using Application.Models;
using System.Diagnostics;
using Interfaces.Interfaces;
using Application.Utils;

namespace Application.Services
{
    public class IOKeepTableService
    {
        private List<TreeNode> TreeNodeList = new List<TreeNode>();
        private TreeInitUtils TreeBuilderUtils = new TreeInitUtils();
        private IIOKeepTableDataAccess iIOKeepTableDataAccess;

        public IOKeepTableService(IIOKeepTableDataAccess _iIOKeepTableDataAccess)
        {
            iIOKeepTableDataAccess = _iIOKeepTableDataAccess;
        }

        public List<TreeNode> IOColumnNamesAsTreeNodes()
        {
            try
            {
                List<string> IONameList = iIOKeepTableDataAccess.IOColumnNames_FromIOKeepTable();
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in IOKeepTableService : IOColumnNamesAsTreeNodes: ex.Message = " + ex.Message);
                Debug.WriteLine($"Exception in IOKeepTableService : IOColumnNamesAsTreeNodes: ex.StackTrace = " + ex.StackTrace);
            }
            return TreeNodeList;
        }

        public List<XYValuePair> GetXYValuePairFromSignalBetween(string Signal, Int64 Start, Int64 Stop)
        {
            List<XYValuePair> ReturnList = new List<XYValuePair>();
            try
            {
                Int64[] XValueWorkList = iIOKeepTableDataAccess.IOXCoordinatesFromSignal_FromIOKeepTable(Signal).ToArray();
                Boolean[] YValueWorkList = iIOKeepTableDataAccess.IOYCoordinatesFromSignal_FromIOKeepTable(Signal).ToArray();
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
                //Debug.WriteLine($"in GetXYValuePairFromSignalBetween. ReturnList.Count = {ReturnList.Count}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in IOKeepTableService : GetXYValuePairFromSignalBetween: ex.Message = " + ex.Message);
                Debug.WriteLine($"Exception in IOKeepTableService : GetXYValuePairFromSignalBetween: ex.StackTrace = " + ex.StackTrace);
            }
            return ReturnList;
        }

        public List<Int64> GetXCordinatesBetween(string Signal, Int64 Start, Int64 Stop)
        {
            List<Int64> ReturnList = new List<Int64>();
            try
            {
                List<Int64> WorkList = iIOKeepTableDataAccess.IOXCoordinatesFromSignal_FromIOKeepTable(Signal);
                foreach (Int64 item in WorkList)
                {
                    if (item > Start && item < Stop)
                    {
                        ReturnList.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in IOKeepTableService : GetXCordinatesBetween: ex.Message = " + ex.Message);
                Debug.WriteLine($"Exception in IOKeepTableService : GetXCordinatesBetween: ex.StackTrace = " + ex.StackTrace);
            }
            return ReturnList;
        }
    }
}
