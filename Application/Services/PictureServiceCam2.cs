using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Services;
using System.Drawing.Imaging;
using System.Drawing;
using System.Diagnostics;
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
        public int NumberOfPicturesInStack()
        {
            return iPictureDataAccessCam2.PicturePathsListFrom_Cam2KeepTable().Count();
        }
        public void UpdatePictureStack()
        {
            PicturePathsList = iPictureDataAccessCam2.PicturePathsListFrom_Cam2KeepTable();
            PicturePathsArray = PicturePathsList.ToArray();
            PictureTimeStampStringList = iPictureDataAccessCam2.PictureTimeStampStringListFrom_Cam2KeepTable();
            PictureTimeStampStringArray = PictureTimeStampStringList.ToArray();
        }
        //public string LeftPicturePathToShow(int LeftPictureNumberInStackToShow)
        //{
        //    if (PicturePathsArray != null)
        //    {
        //        return PicturePathsArray[LeftPictureNumberInStackToShow];
        //    }
        //    return "Cam1KeepPictures/Camera1_1611872350240.jpeg"; //Skall ersättas med någon logga eller något mer neutralt kanske
        //}
        //public string LeftPictureTimestampToShow(int LeftPictureNumberInStackToShow)
        //{
        //    if (PictureTimeStampStringArray != null)
        //    {
        //        return PictureTimeStampStringArray[LeftPictureNumberInStackToShow];
        //    }
        //    return "";
        //}
        public string RightPicturePathToShow(int RightPictureNumberInStackToShow)
        {
            if (PicturePathsArray != null)
            {
                //Debug.WriteLine($"RightPicturePathToShow path to show ::::: {PicturePathsArray[RightPictureNumberInStackToShow]}");
                return PicturePathsArray[RightPictureNumberInStackToShow];
            }
            return "Cam1KeepPictures/Camera1_1611872350240.jpeg"; //Skall ersättas med någon logga eller något mer neutralt kanske
        }
        public string RightPictureTimestampToShow(int RightPictureNumberInStackToShow)
        {
            if (PictureTimeStampStringArray != null)
            {
                return PictureTimeStampStringArray[RightPictureNumberInStackToShow];
            }
            return "";
        }
    }
}


