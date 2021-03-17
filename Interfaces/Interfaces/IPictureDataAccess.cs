using System.Collections.Generic;

namespace Interfaces.Interfaces
{
    public interface IPictureDataAccess
    {
        List<string> PicturePathsListFrom_Cam1KeepTable();
        string[] PicturePathsArrayFrom_Cam1KeepTable();

        List<string> PictureTimeStampStringListFrom_Cam1KeepTable();

        string[] PictureTimeStampStringArrayFrom_Cam1KeepTable();

    }
}