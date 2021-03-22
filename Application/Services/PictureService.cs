using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Services;
using System.Drawing.Imaging;
using System.Drawing;
using System.Diagnostics;
using Interfaces.Interfaces;



namespace Application.Services
{
    public class PictureService
    {
        private List<string> PicturePathsList = new List<string>();
        private string[] PicturePathsArray;
        private List<string> PictureTimeStampStringList = new List<string>();
        private string[] PictureTimeStampStringArray;

        public IPictureDataAccess _PictureDataAccess;
        public PictureService(IPictureDataAccess p)
        {
            _PictureDataAccess = p;
            Debug.WriteLine($"PictureService konstruktor Körs");
        }
        public int NumberOfPicturesInStack()
        {
            return _PictureDataAccess.PicturePathsListFrom_Cam1KeepTable().Count();
        }
        public void UpdatePictureStack()
        {
            PicturePathsList = _PictureDataAccess.PicturePathsListFrom_Cam1KeepTable();
            PicturePathsArray = PicturePathsList.ToArray();
            PictureTimeStampStringList = _PictureDataAccess.PictureTimeStampStringListFrom_Cam1KeepTable();
            PictureTimeStampStringArray = PictureTimeStampStringList.ToArray();
        }
        public string LeftPicturePathToShow(int LeftPictureNumberInStackToShow)
        {
            if (PicturePathsArray != null)
            {
                return PicturePathsArray[LeftPictureNumberInStackToShow];
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


