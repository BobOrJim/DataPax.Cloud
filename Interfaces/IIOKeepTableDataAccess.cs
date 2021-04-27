using System;
using System.Collections.Generic;

namespace Interfaces.Interfaces
{ 
    public interface IIOKeepTableDataAccess
    {
        List<string> IOColumnNames_FromIOKeepTable();
        List<Int64> IOXCoordinatesFromSignal_FromIOKeepTable(string Signal);
        List<Boolean> IOYCoordinatesFromSignal_FromIOKeepTable(string Signal);


    }
}