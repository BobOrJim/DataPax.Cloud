using Infrastructure.Models;
using Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Infrastructure.DataAccess
{
    public class PictureDataAccess : IPictureDataAccess
    {
        private List<string> PicturePathsList;
        private string[] PicturePathsArray;
        private IEFAccess _IEFAccess;

        public PictureDataAccess(EFAccess _iEFAccess)
        {
            _IEFAccess = _iEFAccess;
        }

        //Metod0. Util. Read new data from database
        private void ReadFrom_Cam1KeepTableAndPrepData()
        {
            List<Picture> PictureList = _IEFAccess.Cam1KeepTable.ToList();
            Picture[] PicturesArray = _IEFAccess.Cam1KeepTable.ToArray();
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
