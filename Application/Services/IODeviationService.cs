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
        private List<ListItem> ListItemList = new List<ListItem>(); //Work data, skall hämtas från IOService senare.
        public IIODeviationDataAccess iIODeviationDataAccess;

        public IODeviationService(IIODeviationDataAccess _iIODeviationDataAccess)
        {
            iIODeviationDataAccess = _iIODeviationDataAccess;
        }



        public List<ListItem> DeviationList()
        {
            ListItemList.Clear();

            foreach (ListItem t in ListItemList)
            {
                //Debug.WriteLine(t.Name);

            }
            return ListItemList;
        }


    }
}


