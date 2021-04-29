using System;
using System.Collections.Generic;

namespace Interfaces.Interfaces
{
    public interface IPictureDataAccessCam2
    {
        List<string> PicturePathsStringList_FromCam2KeepTable(Int64 StartTime, Int64 EndTime);
        List<string> PictureTimeStampStringList_FromCam2KeepTable(Int64 StartTime, Int64 EndTime);
    }
}