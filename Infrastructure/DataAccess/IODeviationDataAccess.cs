using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Models;
using Interfaces.Interfaces;

namespace Infrastructure.DataAccess
{
    public class IODeviationDataAccess : IIODeviationDataAccess
    {
        private List<string> DeviationList = new List<string>();
        EFAccessIODeviationTable eFAccessIODeviationTable;


        public IODeviationDataAccess(EFAccessIODeviationTable _eFAccessIODeviationTable)
        {
            eFAccessIODeviationTable = _eFAccessIODeviationTable;
        }

        public List<string> DeviationListFrom_IODeviationTable()
        {
            List<IOSample> IOSampleList = eFAccessIODeviationTable.IODeviationTable.ToList();
            foreach (IOSample iOSample in IOSampleList)
            {
                DeviationList.Clear();
                DeviationList.Add(iOSample.DeviationID_TEXT);
            }
            return DeviationList;
        }


    }
}
