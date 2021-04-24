using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ListItem
    {

        public string Name { get; set; }
        public int Id { get; set; } //Varje ListTime har ett unikt id. Name skulle kunna vara samma.

        public Int64 Timestamp_unix_BIGINT { get; set; }

        //Här kan man tänkasig att starttid och stoptid skall in.


    }
}
