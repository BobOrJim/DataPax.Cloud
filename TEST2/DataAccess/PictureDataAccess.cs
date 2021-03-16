using Infrastructure.Models;
using Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace Infrastructure.DataAccess
{
    public class PictureDataAccess : IPictureDataAccess
    {
        private List<string> PicturePathsList = new List<string>();
        private string[] PicturePathsArray;
        private IEFAccess _IEFAccess;

        public PictureDataAccess(EFAccess _iEFAccess)
        {
            _IEFAccess = _iEFAccess;
            Debug.WriteLine($"PictureDataAccess konstruktor Körs");
        }

        //Metod0. Utils. Private.
        private void ReadFrom_Cam1KeepTableAndPrepData()
        {
            List<Picture> PictureList = _IEFAccess.Cam1KeepTable.ToList();
            Picture[] PicturesArray = _IEFAccess.Cam1KeepTable.ToArray();
            PicturePathsList.Clear();
            foreach (Picture picture in PictureList)
            {
                string tmpPath = "Cam1KeepPictures/" + picture.FileNameCurrent_TEXT + ".jpeg";
                PicturePathsList.Add(tmpPath);
            }
            PicturePathsArray = PicturePathsList.ToArray();
        }

        //Metod 1. Returnerar alla paths, i anropad tabell som lista.
        public List<string> PicturePathsListFrom_Cam1KeepTable()
        {
            ReadFrom_Cam1KeepTableAndPrepData();
            return PicturePathsList;
        }

        //Metod 2. Returnerar alla paths, i anropad tabell som lista.
        public string[] PicturePathsArrayFrom_Cam1KeepTable()
        {
            ReadFrom_Cam1KeepTableAndPrepData();
            return PicturePathsArray;
        }

        //Metod 2. Returnerar alla bildern i anropad tabell mellan tid 1 och tid 2

    }
}
