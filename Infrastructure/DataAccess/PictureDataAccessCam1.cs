using Infrastructure.Models;
using Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

//The interface of this class is a utility/Data-access for pictureService in Application. And a pictureService object is used in the PresentationPage

namespace Infrastructure.DataAccess
{
    public class PictureDataAccessCam1 : IPictureDataAccessCam1
    {
        private List<string> PicturePathsStringList = new List<string>();
        private List<string> PictureTimeStampStringList = new List<string>();
        EFAccessCam1KeepTable eFAccessCam1KeepTable;
        public PictureDataAccessCam1(EFAccessCam1KeepTable _eFAccessCam1KeepTable)
        {
            eFAccessCam1KeepTable = _eFAccessCam1KeepTable;
        }

        private void UpdatePictureData_FromCam1Keep(Int64 StartTime, Int64 EndTime)
        {
            List<Picture> PictureList = eFAccessCam1KeepTable.Cam1KeepTable.ToList();
            PicturePathsStringList.Clear();
            PictureTimeStampStringList.Clear();
            foreach (Picture picture in PictureList)
            {
                if (picture.Timestamp_unix_BIGINT > StartTime && picture.Timestamp_unix_BIGINT < EndTime)
                {
                    PicturePathsStringList.Add("Cam1KeepPictures/" + picture.FileNameCurrent_TEXT + ".jpeg");
                    PictureTimeStampStringList.Add(picture.Datestamp_TEXT + "." + picture.FileNameCurrent_TEXT.Substring(picture.FileNameCurrent_TEXT.Length - 3));
                }
            }
        }

        //Returnerar alla picture patch betwen startTime and stopTime
        public List<string> PicturePathsStringList_FromCam1KeepTable(Int64 StartTime, Int64 EndTime)
        {
            UpdatePictureData_FromCam1Keep(StartTime, EndTime);
            return PicturePathsStringList;
        }

        //Returnerar alla picture timestamps betwen startTime and stopTime
        public List<string> PictureTimeStampStringList_FromCam1KeepTable(Int64 StartTime, Int64 EndTime)
        {
            UpdatePictureData_FromCam1Keep(StartTime, EndTime);
            return PictureTimeStampStringList;
        }
    }
}
