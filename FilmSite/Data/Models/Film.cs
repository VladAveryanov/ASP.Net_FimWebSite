using FilmSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSite.Models
{
    public class Film
    {
        public int FilmID { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public string Video { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public double Price { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }

    }
}
