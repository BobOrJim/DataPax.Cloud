using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            int counter = 0;
            WorkStringList = iIODeviationDataAccess.DeviationNameStringList_FromIODeviationTable();
            WorkInt64List = iIODeviationDataAccess.DeviationTimeStampList_FromIODeviationTable();
            foreach (string s in WorkStringList)
            {
                listItem = new ListItem();
                listItem.Id = counter;
                listItem.Timestamp_unix_BIGINT = WorkInt64List[counter];
                listItem.Name = s;
                counter += 1;
                ListItemList.Add(listItem);
            }
            return ListItemList;
        }
    }
}


