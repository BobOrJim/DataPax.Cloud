using Infrastructure.Models;
using Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


//Syftet med denna klass är att vara utillity vid skapandet av en PictureService.
//"PresentationPage" använder en PictureService

namespace Infrastructure.DataAccess
{
    public class PictureDataAccessCam2 : IPictureDataAccessCam2
    {
        private List<string> PicturePathsList = new List<string>();
        private string[] PicturePathsArray;
        private List<string> PictureTimeStampStringList = new List<string>();
        private string[] PictureTimeStampStringArray;
        EFAccessCam2KeepTable eFAccessCam2KeepTable;
        public PictureDataAccessCam2(EFAccessCam2KeepTable _eFAccessCam2KeepTable)
        {
            eFAccessCam2KeepTable = _eFAccessCam2KeepTable;
        }

        //Metod0. Utils. Private.
        private void ReadFrom_Cam2KeepTableAndPrepData()
        {
            List<Picture> PictureList = eFAccessCam2KeepTable.Cam2KeepTable.ToList();
            Picture[] PicturesArray = eFAccessCam2KeepTable.Cam2KeepTable.ToArray();
            PicturePathsList.Clear();
            Debug.WriteLine($"Nu sker anrop till DB från PictureDataAccessCam2, kolla så det inte blir för många av dessa, bortsett från init, bör de bara köras när någon tidModell ändras");
            foreach (Picture picture in PictureList)
            {
                PicturePathsList.Add("Cam2KeepPictures/" + picture.FileNameCurrent_TEXT + ".jpeg");
                //Building a label(string), that will show the timestamp with 3 decimals after the second.
                PictureTimeStampStringList.Add(picture.Datestamp_TEXT + "." + picture.FileNameCurrent_TEXT.Substring(picture.FileNameCurrent_TEXT.Length - 3));
            }
            PicturePathsArray = PicturePathsList.ToArray();
            PictureTimeStampStringArray = PictureTimeStampStringList.ToArray();
        }


        //Metod 1. Returnerar alla paths, i anropad tabell som lista.
        public List<string> PicturePathsListFrom_Cam2KeepTable()
        {
            ReadFrom_Cam2KeepTableAndPrepData();
            return PicturePathsList;
        }


        //Metod 2. Returnerar alla paths, i anropad tabell som array
        public string[] PicturePathsArrayFrom_Cam2KeepTable()
        {
            ReadFrom_Cam2KeepTableAndPrepData();
            return PicturePathsArray;
        }


        //Metod 3. Returnerar alla timestamp, i anropad tabell som lista.
        public List<string> PictureTimeStampStringListFrom_Cam2KeepTable()
        {
            ReadFrom_Cam2KeepTableAndPrepData();
            return PictureTimeStampStringList;
        }


        //Metod 4. Returnerar alla timestamp, i anropad tabell som array
        public string[] PictureTimeStampStringArrayFrom_Cam2KeepTable()
        {
            ReadFrom_Cam2KeepTableAndPrepData();
            return PictureTimeStampStringArray;
        }
    }
}


