using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SongApp.Models
{
    public class Song
    {
        [Key]
        public int SongID { get; set; }
        public string  SongName { get; set; }
        public string SongType { get; set; }
        public string SingerName { get; set; }
    }
}
