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
        private IPictureDataAccessCam1 _PictureDataAccessCam1;

        public PictureServiceCam1(IPictureDataAccessCam1 p)
        {
            _PictureDataAccessCam1 = p;
        }
        public int NumberOfPicturesInStack(Int64 StartTime, Int64 EndTime)
        {
            int result = -1;
            try
            {
                result = _PictureDataAccessCam1.PicturePathsStringList_FromCam1KeepTable(StartTime, EndTime).Count();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in PictureServiceCam1 : NumberOfPicturesInStack: ex.Message = " + ex.Message);
                Debug.WriteLine($"Exception in PictureServiceCam1 : NumberOfPicturesInStack: ex.StackTrace = " + ex.StackTrace);
            }            
            return result;
        }
        public void UpdatePictureStack(Int64 StartTime, Int64 EndTime)
        {

            try
            {
                PicturePathsList = _PictureDataAccessCam1.PicturePathsStringList_FromCam1KeepTable(StartTime, EndTime);
                PicturePathsArray = PicturePathsList.ToArray();
                PictureTimeStampStringList = _PictureDataAccessCam1.PictureTimeStampStringList_FromCam1KeepTable(StartTime, EndTime);
                PictureTimeStampStringArray = PictureTimeStampStringList.ToArray();
                //Debug.WriteLine($"In PictureServiceCam1 / UpdatePictureStack. PicturePathsArray.Length =  {PicturePathsArray.Length}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in PictureServiceCam1 : UpdatePictureStack: ex.Message = " + ex.Message);
                Debug.WriteLine($"Exception in PictureServiceCam1 : UpdatePictureStack: ex.StackTrace = " + ex.StackTrace);
            }
        }

        public string LeftPicturePathToShow(int LeftPictureNumberInStackToShow)
        {
            try
            {
                if (PicturePathsArray != null && LeftPictureNumberInStackToShow < PicturePathsArray.Length)
                {
                    return PicturePathsArray[LeftPictureNumberInStackToShow];
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in PictureServiceCam1 : LeftPicturePathToShow: ex.Message = " + ex.Message);
                Debug.WriteLine($"Exception in PictureServiceCam1 : LeftPicturePathToShow: ex.StackTrace = " + ex.StackTrace);
            }
            return "Images/Logo.jpeg";
        }

        public string LeftPictureTimestampToShow(int LeftPictureNumberInStackToShow)
        {
            try
            {
                if (PictureTimeStampStringArray != null && LeftPictureNumberInStackToShow < PicturePathsArray.Length)
                {
                    return PictureTimeStampStringArray[LeftPictureNumberInStackToShow];
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in PictureServiceCam1 : LeftPictureTimestampToShow: ex.Message = " + ex.Message);
                Debug.WriteLine($"Exception in PictureServiceCam1 : LeftPictureTimestampToShow: ex.StackTrace = " + ex.StackTrace);
            }
            return "No picture found";
        }
    }
}


