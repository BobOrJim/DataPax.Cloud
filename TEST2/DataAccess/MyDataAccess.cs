
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Text;

namespace Infrastructure.DataAccess
{
    public class MyDataAccess : DbContext
    {
        public MyDataAccess(DbContextOptions options) : base(options) { }

        //public DbSet<Person> People { get; set; } //okaj, vit text här, är hans tabell namn.


        public DbSet<Picture> Cam1KeepTable { get; set; }
        
        //tom 25:00

        //Här vill jag ha en metod med följande in/ut
        //In param är två Int64 (bigInt i SQL?)

        //return är lista med string, där varje string är en file PATH till en bild.





    }
}
