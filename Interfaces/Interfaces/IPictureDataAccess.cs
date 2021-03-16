using System.Collections.Generic;

namespace Interfaces.Interfaces
{
    public interface IPictureDataAccess
    {
        string[] PicturePathsArrayFrom_Cam1KeepTable();
        List<string> PicturePathsListFrom_Cam1KeepTable();
    }
}