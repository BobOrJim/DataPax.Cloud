using System.Collections.Generic;

namespace Interfaces.Interfaces
{
    public interface IPictureDataAccessCam2
    {
        string[] PicturePathsArrayFrom_Cam2KeepTable();
        List<string> PicturePathsListFrom_Cam2KeepTable();
        string[] PictureTimeStampStringArrayFrom_Cam2KeepTable();
        List<string> PictureTimeStampStringListFrom_Cam2KeepTable();
    }
}