using Infrastructure.Models;
using Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


//The interface of this class is a utility/Data-access for pictureService in Application. And a pictureService object is used in the PresentationPage

namespace Infrastructure.DataAccess
{
    public class PictureDataAccessCam2 : IPictureDataAccessCam2
    {
        private List<string> PicturePathsStringList = new List<string>();
        private List<string> PictureTimeStampStringList = new List<string>();
        private EFAccessCam2KeepTable eFAccessCam2KeepTable;
        public PictureDataAccessCam2(EFAccessCam2KeepTable _eFAccessCam2KeepTable)
        {
            eFAccessCam2KeepTable = _eFAccessCam2KeepTable;
        }

        private void UpdatePictureData_FromCam2Keep(Int64 StartTime, Int64 EndTime)
        {
            try
            {
                List<Picture> PictureList = eFAccessCam2KeepTable.Cam2KeepTable.ToList();
                PicturePathsStringList.Clear();
                PictureTimeStampStringList.Clear();
                foreach (Picture picture in PictureList)
                {
                    if (picture.Timestamp_unix_BIGINT > StartTime && picture.Timestamp_unix_BIGINT < EndTime)
                    {
                        PicturePathsStringList.Add("Cam2KeepPictures/" + picture.FileNameCurrent_TEXT + ".jpeg");
                        PictureTimeStampStringList.Add(picture.Datestamp_TEXT + "." + picture.FileNameCurrent_TEXT.Substring(picture.FileNameCurrent_TEXT.Length - 3));
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in PictureDataAccessCam2 : UpdatePictureData_FromCam2Keep: ex.Message = " + ex.Message);
                Debug.WriteLine($"Exception in PictureDataAccessCam2 : UpdatePictureData_FromCam2Keep: ex.StackTrace = " + ex.StackTrace);
            }
        }

        //Returnerar alla picture patch betwen startTime and stopTime
        public List<string> PicturePathsStringList_FromCam2KeepTable(Int64 StartTime, Int64 EndTime)
        {
            try
            {
                UpdatePictureData_FromCam2Keep(StartTime, EndTime);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in PictureDataAccessCam2 : PicturePathsStringList_FromCam2KeepTable: ex.Message = " + ex.Message);
                Debug.WriteLine($"Exception in PictureDataAccessCam2 : PicturePathsStringList_FromCam2KeepTable: ex.StackTrace = " + ex.StackTrace);
            }
            return PicturePathsStringList;
        }

        //Returnerar alla picture timestamps betwen startTime and stopTime
        public List<string> PictureTimeStampStringList_FromCam2KeepTable(Int64 StartTime, Int64 EndTime)
        {
            try
            {
                UpdatePictureData_FromCam2Keep(StartTime, EndTime);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in PictureDataAccessCam2 : PictureTimeStampStringList_FromCam2KeepTable: ex.Message = " + ex.Message);
                Debug.WriteLine($"Exception in PictureDataAccessCam2 : PictureTimeStampStringList_FromCam2KeepTable: ex.StackTrace = " + ex.StackTrace);
            }
            return PictureTimeStampStringList;
        }
    }
}

