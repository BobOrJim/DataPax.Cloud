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
    public class PictureDataAccessCam1 : IPictureDataAccessCam1
    {
        private List<string> PicturePathsList = new List<string>();
        private string[] PicturePathsArray;
        private List<string> PictureTimeStampStringList = new List<string>();
        private string[] PictureTimeStampStringArray;
        EFAccessCam1KeepTable eFAccessCam1KeepTable;
        public PictureDataAccessCam1(EFAccessCam1KeepTable _eFAccessCam1KeepTable)
        {
            eFAccessCam1KeepTable = _eFAccessCam1KeepTable;
        }

        //Metod0. Utils. Private.
        private void ReadFrom_Cam1KeepTableAndPrepData()
        {
            List<Picture> PictureList = eFAccessCam1KeepTable.Cam1KeepTable.ToList();
            Picture[] PicturesArray = eFAccessCam1KeepTable.Cam1KeepTable.ToArray();
            PicturePathsList.Clear();
            //Debug.WriteLine($"Nu sker anrop till DB från PictureDataAccessCam1, kolla så det inte blir för många av dessa, bortsett från init, bör de bara köras när någon tidModell ändras");
            foreach (Picture picture in PictureList)
            {
                PicturePathsList.Add("Cam1KeepPictures/" + picture.FileNameCurrent_TEXT + ".jpeg");
                //Building a label(string), that will show the timestamp with 3 decimals after the second.
                PictureTimeStampStringList.Add(picture.Datestamp_TEXT + "." + picture.FileNameCurrent_TEXT.Substring(picture.FileNameCurrent_TEXT.Length - 3));
            }
            PicturePathsArray = PicturePathsList.ToArray();
            PictureTimeStampStringArray = PictureTimeStampStringList.ToArray();
        }


        //Metod 1. Returnerar alla paths, i anropad tabell som lista.
        public List<string> PicturePathsListFrom_Cam1KeepTable()
        {
            ReadFrom_Cam1KeepTableAndPrepData();
            return PicturePathsList;
        }


        //Metod 2. Returnerar alla paths, i anropad tabell som array
        public string[] PicturePathsArrayFrom_Cam1KeepTable()
        {
            ReadFrom_Cam1KeepTableAndPrepData();
            return PicturePathsArray;
        }


        //Metod 3. Returnerar alla timestamp, i anropad tabell som lista.
        public List<string> PictureTimeStampStringListFrom_Cam1KeepTable()
        {
            ReadFrom_Cam1KeepTableAndPrepData();
            return PictureTimeStampStringList;
        }


        //Metod 4. Returnerar alla timestamp, i anropad tabell som array
        public string[] PictureTimeStampStringArrayFrom_Cam1KeepTable()
        {
            ReadFrom_Cam1KeepTableAndPrepData();
            return PictureTimeStampStringArray;
        }
    }
}
