using System;
using System.ComponentModel.DataAnnotations;

namespace musicrush.Models
{
    public class Album
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Artist { get; set; }
    }
}