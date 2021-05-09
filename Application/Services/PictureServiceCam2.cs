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
        private IPictureDataAccessCam2 iPictureDataAccessCam2;

        public PictureServiceCam2(IPictureDataAccessCam2 _iPictureDataAccessCam2)
        {
            iPictureDataAccessCam2 = _iPictureDataAccessCam2;
        }
        public int NumberOfPicturesInStack(Int64 StartTime, Int64 EndTime)
        {
            int result = -1;
            try
            {
                return result = iPictureDataAccessCam2.PicturePathsStringList_FromCam2KeepTable(StartTime, EndTime).Count();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in PictureServiceCam2 : NumberOfPicturesInStack: ex.Message = " + ex.Message);
                Debug.WriteLine($"Exception in PictureServiceCam2 : NumberOfPicturesInStack: ex.StackTrace = " + ex.StackTrace);
            }
            return result;
        }

        public void UpdatePictureStack(Int64 StartTime, Int64 EndTime)
        {
            try
            {
                PicturePathsList = iPictureDataAccessCam2.PicturePathsStringList_FromCam2KeepTable(StartTime, EndTime);
                PicturePathsArray = PicturePathsList.ToArray();
                PictureTimeStampStringList = iPictureDataAccessCam2.PictureTimeStampStringList_FromCam2KeepTable(StartTime, EndTime);
                PictureTimeStampStringArray = PictureTimeStampStringList.ToArray();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in PictureServiceCam2 : UpdatePictureStack: ex.Message = " + ex.Message);
                Debug.WriteLine($"Exception in PictureServiceCam2 : UpdatePictureStack: ex.StackTrace = " + ex.StackTrace);
            }
        }


        public string RightPicturePathToShow(int RightPictureNumberInStackToShow)
        {
            try
            {
                if (PicturePathsArray != null && RightPictureNumberInStackToShow < PicturePathsArray.Length)
                {
                    return PicturePathsArray[RightPictureNumberInStackToShow];
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in PictureServiceCam2 : RightPicturePathToShow: ex.Message = " + ex.Message);
                Debug.WriteLine($"Exception in PictureServiceCam2 : RightPicturePathToShow: ex.StackTrace = " + ex.StackTrace);
            }
            return "Images/Logo.jpeg";
        }
        public string RightPictureTimestampToShow(int RightPictureNumberInStackToShow)
        {
            try
            {
                if (PictureTimeStampStringArray != null && RightPictureNumberInStackToShow < PicturePathsArray.Length)
                {
                    return PictureTimeStampStringArray[RightPictureNumberInStackToShow];
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in PictureServiceCam2 : RightPictureTimestampToShow: ex.Message = " + ex.Message);
                Debug.WriteLine($"Exception in PictureServiceCam2 : RightPictureTimestampToShow: ex.StackTrace = " + ex.StackTrace);
            }
            return "No picture found";
        }
    }
}


