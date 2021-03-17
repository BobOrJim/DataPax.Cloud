
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess
{
    public class EFAccess : DbContext, IEFAccess
    {
        public EFAccess(DbContextOptions options) : base(options) { }
        public DbSet<Picture> Cam1KeepTable { get; set; }
    }
}
