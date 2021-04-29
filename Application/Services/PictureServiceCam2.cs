using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Interfaces.Interfaces;

namespace Application.Services
{
    public class PictureServiceCam2
    {
        private List<string> PicturePathsList = new List<string>();
        private string[] PicturePathsArray;
        private List<string> PictureTimeStampStringList = new List<string>();
        private string[] PictureTimeStampStringArray;
        public IPictureDataAccessCam2 iPictureDataAccessCam2;

        public PictureServiceCam2(IPictureDataAccessCam2 _iPictureDataAccessCam2)
        {
            iPictureDataAccessCam2 = _iPictureDataAccessCam2;
        }
        public int NumberOfPicturesInStack(Int64 StartTime, Int64 EndTime)
        {
            return iPictureDataAccessCam2.PicturePathsStringList_FromCam2KeepTable(StartTime, EndTime).Count();
        }
        public void UpdatePictureStack(Int64 StartTime, Int64 EndTime)
        {
            PicturePathsList = iPictureDataAccessCam2.PicturePathsStringList_FromCam2KeepTable(StartTime, EndTime);
            PicturePathsArray = PicturePathsList.ToArray();
            PictureTimeStampStringList = iPictureDataAccessCam2.PictureTimeStampStringList_FromCam2KeepTable(StartTime, EndTime);
            PictureTimeStampStringArray = PictureTimeStampStringList.ToArray();
        }


        public string RightPicturePathToShow(int RightPictureNumberInStackToShow)
        {
            if (PicturePathsArray != null && RightPictureNumberInStackToShow < PicturePathsArray.Length)
            {
                return PicturePathsArray[RightPictureNumberInStackToShow];
            }
            return "Images/Logo.jpeg";
        }
        public string RightPictureTimestampToShow(int RightPictureNumberInStackToShow)
        {
            if (PictureTimeStampStringArray != null && RightPictureNumberInStackToShow < PicturePathsArray.Length)
            {
                return PictureTimeStampStringArray[RightPictureNumberInStackToShow];
            }
            return "No picture found";
        }
    }
}


