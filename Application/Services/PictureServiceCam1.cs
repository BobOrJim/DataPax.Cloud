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
        public int NumberOfPicturesInStack()
        {
            return _PictureDataAccessCam1.PicturePathsListFrom_Cam1KeepTable().Count();
        }
        public void UpdatePictureStack()
        {
            PicturePathsList = _PictureDataAccessCam1.PicturePathsListFrom_Cam1KeepTable();
            PicturePathsArray = PicturePathsList.ToArray();
            PictureTimeStampStringList = _PictureDataAccessCam1.PictureTimeStampStringListFrom_Cam1KeepTable();
            PictureTimeStampStringArray = PictureTimeStampStringList.ToArray();
        }
        public string LeftPicturePathToShow(int LeftPictureNumberInStackToShow)
        {
            if (PicturePathsArray != null)
            {
                return PicturePathsArray[LeftPictureNumberInStackToShow-1];
            }
            return "Cam1KeepPictures/Camera1_1611872350240.jpeg"; //Skall ersättas med någon logga eller något mer neutralt kanske
        }
        public string LeftPictureTimestampToShow(int LeftPictureNumberInStackToShow)
        {
            if (PictureTimeStampStringArray != null)
            {
                return PictureTimeStampStringArray[LeftPictureNumberInStackToShow];
            }
            return "";
        }
        //public string RightPicturePathToShow(int RightPictureNumberInStackToShow)
        //{
        //    if (PicturePathsArray != null)
        //    {
        //        //Debug.WriteLine($"RightPicturePathToShow path to show ::::: {PicturePathsArray[RightPictureNumberInStackToShow]}");
        //        return PicturePathsArray[RightPictureNumberInStackToShow];
        //    }
        //    return "Cam1KeepPictures/Camera1_1611872350240.jpeg"; //Skall ersättas med någon logga eller något mer neutralt kanske
        //}
        //public string RightPictureTimestampToShow(int RightPictureNumberInStackToShow)
        //{
        //    if (PictureTimeStampStringArray != null)
        //    {
        //        return PictureTimeStampStringArray[RightPictureNumberInStackToShow];
        //    }
        //    return "";
        //}
    }
}


