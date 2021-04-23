using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Models;
using Interfaces.Interfaces;

namespace Infrastructure.DataAccess
{
    public class IOKeepTableDataAccess : IIOKeepTableDataAccess
    {
        EFAccessIOKeepTable eFAccessIOKeepTable;
        public IOKeepTableDataAccess(EFAccessIOKeepTable _eFAccessIOKeepTable)
        {
            eFAccessIOKeepTable = _eFAccessIOKeepTable;
        }


        public void slask()
        {

        }


    }
}
