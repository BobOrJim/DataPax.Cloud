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
        private List<Int64> WorkInt64List = new List<Int64>();

        public IIODeviationDataAccess iIODeviationDataAccess;

        public IODeviationService(IIODeviationDataAccess _iIODeviationDataAccess)
        {
            iIODeviationDataAccess = _iIODeviationDataAccess;
        }

        public List<ListItem> DeviationListItemList()
        {
            ListItemList.Clear();
            ListItem listItem;
            int ID = 0;
            WorkStringList = iIODeviationDataAccess.DeviationNameStringList_FromIODeviationTable();
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


