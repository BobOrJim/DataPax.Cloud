
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess
{
    public class EFAccessCam2KeepTable : DbContext
    {
        public EFAccessCam2KeepTable(DbContextOptions options) : base(options) { }


        public DbSet<Picture> Cam2KeepTable { get; set; }

    }
}


