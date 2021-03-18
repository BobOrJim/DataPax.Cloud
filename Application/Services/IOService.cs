﻿using System;
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
    public class IOService
    {
        private List<string> IONameList = new List<string>();
        private string[] IONameArray;

        private void UpdateIOStack()
        {
            IONameList = myMoqColumn(); //Här skall det in anrop till IODataAccess, vilken inte är skapad ännu.
            IONameArray = IONameList.ToArray();
        }

        public List<string> IONames()
        {
            UpdateIOStack();
            return IONameList;
        }

        //NOTERING: Detta är kolumn namn. Jag kommer ha två alternativ framöver:
        //1: Försöka plocka ur kolumnnamnen från EF
        //2: Hårdkoda modell, (samma som för picture, dvs kolumn blir en Model. Jag skall välja den lätta tills Docker grejen är färdig.
        public List<string> myMoqColumn()
        {
            //Obs, underscore är radbrytare, inte mellanslag. Dvs det är fyra kategorier.
            List<string> tmpList = new List<string>();
            tmpList.Clear();
            tmpList.Add("Line 1_Machine 1_IO group 1_IO A");
            tmpList.Add("Line 1_Machine 1_IO group 1_IO B");
            tmpList.Add("Line 1_Machine 1_IO group 2_IO C");
            tmpList.Add("Line 1_Machine 1_IO group 2_IO D");
            tmpList.Add("Line 1_Machine 2_IO group 2_IO C");
            tmpList.Add("Line 1_Machine 2_IO group 2_IO D");
            tmpList.Add("Line 2_Machine 2_IO group 2_IO C");
            tmpList.Add("Line 2_Machine 2_IO group 2_IO D");
            tmpList.Add("Line 2_Machine 3_IO group 2_IO C");
            tmpList.Add("Line 2_Machine 3_IO group 3_IO D");
            return tmpList;
        }
    }
}


