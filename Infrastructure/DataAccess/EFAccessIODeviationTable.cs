
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess
{
    public class EFAccessIODeviationTable : DbContext
    {
        public EFAccessIODeviationTable(DbContextOptions<EFAccessIODeviationTable> options) : base(options) { }



        public DbSet<IOSample> IODeviationTable { get; set; }

    }
}


