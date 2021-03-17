using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSite.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CardNumber { get; set; }
        public List<Film> purchasedFilms { get; set; }
        public Cart customerCart { get; set; }
    }
}
