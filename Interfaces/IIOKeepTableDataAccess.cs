using System.Collections.Generic;

namespace Interfaces.Interfaces
{ 
    public interface IIOKeepTableDataAccess
    {
        List<string> IOColumnNames_FromIOKeepTable();
    }
}