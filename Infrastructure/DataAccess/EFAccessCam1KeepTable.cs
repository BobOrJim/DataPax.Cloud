
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess
{
    public class EFAccessCam1KeepTable : DbContext
    {
        public EFAccessCam1KeepTable(DbContextOptions<EFAccessCam1KeepTable> options) : base(options) { }

        public DbSet<Picture> Cam1KeepTable { get; set; }

    }
}


