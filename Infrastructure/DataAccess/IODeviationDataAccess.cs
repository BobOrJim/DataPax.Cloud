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
        private List<string> DeviationList = new List<string>();
        EFAccessIODeviationTable eFAccessIODeviationTable;

        public IODeviationDataAccess(EFAccessIODeviationTable _eFAccessIODeviationTable)
        {
            eFAccessIODeviationTable = _eFAccessIODeviationTable;
        }

        public List<string> DeviationStringList_FromIODeviationTable()
        {
            List<IOSample> IOSampleList = eFAccessIODeviationTable.IODeviationTable.ToList();
            //Debug.WriteLine($"In DeviationStringList_FromIODeviationTable. längd på IOSampleList är:  {IOSampleList.Count()}");
            DeviationList.Clear();
            foreach (IOSample iOSample in IOSampleList)
            {
                DeviationList.Add(iOSample.DeviationID_TEXT);
            }
            return DeviationList;
        }





    }
}
