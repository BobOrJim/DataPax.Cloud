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

        EFAccessIODeviationTable eFAccessIODeviationTable;

        public IODeviationDataAccess(EFAccessIODeviationTable _eFAccessIODeviationTable)
        {
            eFAccessIODeviationTable = _eFAccessIODeviationTable;
        }

        public List<string> DeviationNameStringList_FromIODeviationTable()
        {
            List<IOSample> IOSampleList = eFAccessIODeviationTable.IODeviationTable.ToList();
            DeviationNameStringList.Clear();
            foreach (IOSample iOSample in IOSampleList)
            {
                DeviationNameStringList.Add(iOSample.DeviationID_TEXT);
            }
            return DeviationNameStringList;
        }

        public List<Int64> DeviationTimeStampList_FromIODeviationTable()
        {
            List<IOSample> IOSampleList = eFAccessIODeviationTable.IODeviationTable.ToList();
            DeviationTimeStampList.Clear();
            foreach (IOSample iOSample in IOSampleList)
            {
                DeviationTimeStampList.Add(iOSample.Timestamp_unix_BIGINT);
            }
            return DeviationTimeStampList;
        }

    }
}
