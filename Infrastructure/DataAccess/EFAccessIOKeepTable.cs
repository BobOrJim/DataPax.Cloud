
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess
{
    public class EFAccessIOKeepTable : DbContext
    {
        public EFAccessIOKeepTable(DbContextOptions options) : base(options) { }


        public DbSet<IOSample> IOKeepTable { get; set; }

    }
}


