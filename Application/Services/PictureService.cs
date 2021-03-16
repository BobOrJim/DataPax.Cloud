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

namespace Application.Service
{
    public class PictureService
    {
        private List<string> PicturePathsList = new List<string>();
        private string[] PicturePathsArray;
        private string[] PictureTimeStampsArray;

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
            //PictureTimeStampsArray = 
        }
        public string LeftPicturePathToShow(int LeftPictureNumberInStackToShow)
        {
            if (PicturePathsArray != null)
            {
                return PicturePathsArray[LeftPictureNumberInStackToShow];
            }
            return "Cam1KeepPictures/Camera1_1611872350240.jpeg"; //Skall ersättas med någon logga eller något mer neutralt kanske, vill ju inte reta vingebro mer än nödvändigt.
        }
        public string LeftPictureTimestampToShow(int LeftPictureNumberInStackToShow)
        {
            string tmp1 = PicturePathsArray[LeftPictureNumberInStackToShow]; //Här skall vi använda sista tre siffrorna
            string tmp2 = 

            return "";
        }
        public string RightPicturePathToShow(int RightPictureNumberInStackToShow)
        {
            if (PicturePathsArray != null)
            {
                //Debug.WriteLine($"RightPicturePathToShow path to show ::::: {PicturePathsArray[RightPictureNumberInStackToShow]}");
                return PicturePathsArray[RightPictureNumberInStackToShow];
            }
            return "Cam1KeepPictures/Camera1_1611872350240.jpeg"; //Skall ersättas med någon logga eller något mer neutralt kanske, vill ju inte reta vingebro mer än nödvändigt.
        }
        public string RightPictureTimestampToShow()
        {
            return "";
        }





        //private PictureFilters _PictureFilters;
        //public PictureStackModel LeftPictureStack { get; private set; }
        //public PictureStackModel RightPictureStack { get; private set; }
        //public PictureModel LeftPictureToBlazorComponent { get; private set; }
        //public PictureModel RightPictureToBlazorComponent { get; private set; }


        //här kan det även finnas return paths with filter osv osv.
        //public List<string> ReturnUnmoddedListOfPathsFixaSenare()
        //{
        //    return _PictureDataAccess.PicturePathsListFrom_Cam1KeepTable();
        //}



        //public void UpdatePictureStacks(TimeModel StartTime, TimeModel EndTime, string Camera1Name, string Camera2Name)
        //{
        //    LeftPictureStack = new PictureStackModel(StartTime, EndTime, Camera1Name);
        //    RightPictureStack = new PictureStackModel(StartTime, EndTime, Camera2Name);


        //}

        //Funk nedan skall snyggas till... efter att EF rullar..., om null kan jag använda någon typ av loga bild med DataPax
        //public void LoadPictureWithNumber(PictureStackModel _PictureStack, int Number)
        //{
        //if (_PictureStack == RightPictureStack)
        //    RightPictureToBlazorComponent = _PictureStack._PictureStack[Number];
        //if (_PictureStack == LeftPictureStack)
        //    LeftPictureToBlazorComponent = _PictureStack._PictureStack[Number];
        //}

        //public PictureStackModel ApplyMotionFilterOnPictureStack(PictureStackModel _PictureStack)
        //{
        //    return _PictureFilters.ApplyMotionFilter(_PictureStack);
        //}

    }
}
