
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Models
{
    [Keyless]
    public class Picture
    {
        public Int64 Timestamp_unix_BIGINT { get; set; }
        public string FileNameCurrent_TEXT { get; set; }
        public string FileEndingCurrent_TEXT { get; set; }
        public string Datestamp_TEXT { get; set; }
    }
}
