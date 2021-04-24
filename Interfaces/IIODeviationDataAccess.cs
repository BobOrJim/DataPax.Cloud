using System;
using System.Collections.Generic;


namespace Interfaces.Interfaces
{
    public interface IIODeviationDataAccess
    {
        List<string> DeviationNameStringList_FromIODeviationTable();
        List<Int64> DeviationTimeStampList_FromIODeviationTable();
    }
}

