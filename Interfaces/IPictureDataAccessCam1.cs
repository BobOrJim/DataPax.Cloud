using System;
using System.Collections.Generic;

namespace Interfaces.Interfaces
{
    public interface IPictureDataAccessCam1
    {
        List<string> PicturePathsStringList_FromCam1KeepTable(Int64 StartTime, Int64 EndTime);
        List<string> PictureTimeStampStringList_FromCam1KeepTable(Int64 StartTime, Int64 EndTime);

    }
}