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
        public string Description { get; set; }

        public bool currentFilm { get; set; }

    }
}
