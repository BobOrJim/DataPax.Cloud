using System;

namespace Application.Models
{
    public class ListItem
    {
        public string Name { get; set; }
        public int Id { get; set; } //Varje ListTime har ett unikt id. Name kan bli samma.
        public Int64 Timestamp_unix_BIGINT { get; set; }

    }
}
