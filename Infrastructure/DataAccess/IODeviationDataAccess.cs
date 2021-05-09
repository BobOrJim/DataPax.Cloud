using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Infrastructure.Models;
using Interfaces.Interfaces;

namespace Infrastructure.DataAccess
{
    public class IODeviationDataAccess : IIODeviationDataAccess
    {
        private List<string> DeviationNameStringList = new List<string>();
        private List<Int64> DeviationTimeStampList = new List<Int64>();
        private EFAccessIODeviationTable eFAccessIODeviationTable;

        public IODeviationDataAccess(EFAccessIODeviationTable _eFAccessIODeviationTable)
        {
            eFAccessIODeviationTable = _eFAccessIODeviationTable;
        }

        public List<string> DeviationNameStringList_FromIODeviationTable()
        {
            try
            {
                List<IOSample> IOSampleList = eFAccessIODeviationTable.IODeviationTable.ToList();
                DeviationNameStringList.Clear();
                foreach (IOSample iOSample in IOSampleList)
                {
                    DeviationNameStringList.Add(iOSample.DeviationID_TEXT);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in IODeviationDataAccess : DeviationNameStringList_FromIODeviationTable: ex.Message = " + ex.Message);
                Debug.WriteLine($"Exception in IODeviationDataAccess : DeviationNameStringList_FromIODeviationTable: ex.StackTrace = " + ex.StackTrace);
            }
            return DeviationNameStringList;
        }

        public List<Int64> DeviationTimeStampList_FromIODeviationTable()
        {
            try
            {
                List<IOSample> IOSampleList = eFAccessIODeviationTable.IODeviationTable.ToList();
                DeviationTimeStampList.Clear();
                foreach (IOSample iOSample in IOSampleList)
                {
                    DeviationTimeStampList.Add(iOSample.Timestamp_unix_BIGINT);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in IODeviationDataAccess : DeviationTimeStampList_FromIODeviationTable: ex.Message = " + ex.Message);
                Debug.WriteLine($"Exception in IODeviationDataAccess : DeviationTimeStampList_FromIODeviationTable: ex.StackTrace = " + ex.StackTrace);
            }
            return DeviationTimeStampList;
        }

    }
}
