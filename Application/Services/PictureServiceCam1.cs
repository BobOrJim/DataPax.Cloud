using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Interfaces.Interfaces;

namespace Application.Services
{
    public class PictureServiceCam1
    {
        private List<string> PicturePathsList = new List<string>();
        private string[] PicturePathsArray;
        private List<string> PictureTimeStampStringList = new List<string>();
        private string[] PictureTimeStampStringArray;
        public IPictureDataAccessCam1 _PictureDataAccessCam1;

        public PictureServiceCam1(IPictureDataAccessCam1 p)
        {
            _PictureDataAccessCam1 = p;
        }
        public int NumberOfPicturesInStack(Int64 StartTime, Int64 EndTime)
        {
            return _PictureDataAccessCam1.PicturePathsStringList_FromCam1KeepTable(StartTime, EndTime).Count();
        }
        public void UpdatePictureStack(Int64 StartTime, Int64 EndTime)
        {
            PicturePathsList = _PictureDataAccessCam1.PicturePathsStringList_FromCam1KeepTable(StartTime, EndTime);
            PicturePathsArray = PicturePathsList.ToArray();
            PictureTimeStampStringList = _PictureDataAccessCam1.PictureTimeStampStringList_FromCam1KeepTable(StartTime, EndTime);
            PictureTimeStampStringArray = PictureTimeStampStringList.ToArray();
            //Debug.WriteLine($"In PictureServiceCam1 / UpdatePictureStack. PicturePathsArray.Length =  {PicturePathsArray.Length}");
        }

        public string LeftPicturePathToShow(int LeftPictureNumberInStackToShow)
        {
            if (PicturePathsArray != null && LeftPictureNumberInStackToShow < PicturePathsArray.Length)
            {
                return PicturePathsArray[LeftPictureNumberInStackToShow];
            }
            return "Images/Logo.jpeg";
            
        }
        public string LeftPictureTimestampToShow(int LeftPictureNumberInStackToShow)
        {
            if (PictureTimeStampStringArray != null && LeftPictureNumberInStackToShow < PicturePathsArray.Length)
            {
                return PictureTimeStampStringArray[LeftPictureNumberInStackToShow];
            }
            return "No picture found";
        }
    }
}


