using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace musicrush.Models
{
    [Table("Song")]
    public class Song
    {
        public int ID { get; set; }
        public int AlbumId { get; set; }
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Artist { get; set; }
        public int? Rating { get; set; }
        public Album Album { get; set; }
    }
}