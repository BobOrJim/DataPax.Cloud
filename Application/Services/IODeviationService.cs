using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Services;
using System.Drawing.Imaging;
using System.Drawing;
using System.Diagnostics;
using Interfaces.Interfaces;
using Application.Models;

namespace Application.Services
{
    public class IODeviationService
    {
        private List<ListItem> ListItemList = new List<ListItem>();
        private List<string> WorkStringList = new List<string>();

        public IIODeviationDataAccess iIODeviationDataAccess;

        public IODeviationService(IIODeviationDataAccess _iIODeviationDataAccess)
        {
            iIODeviationDataAccess = _iIODeviationDataAccess;
        }


        public List<ListItem> DeviationsList()
        {
            ListItemList.Clear();
            ListItem listItem;
            int ID = 0;
            WorkStringList = iIODeviationDataAccess.DeviationStringList_FromIODeviationTable();
            //Debug.WriteLine($"Antal element i WorkStringList är : {WorkStringList.Count()}");

            foreach (string s in WorkStringList)
            {
                listItem = new ListItem();
                listItem.Id = ID;
                ID += 1;
                listItem.Name = s;
                ListItemList.Add(listItem);
            }
            return ListItemList;
        }
    }
}


