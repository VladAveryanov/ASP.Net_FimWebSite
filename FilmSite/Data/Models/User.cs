using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSite.Models
{
    public class User
    {
        public int ID { get; set; }

        //[EmailAddress]
        //[Display(Name = "Email Address")]
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }
        public string Email { get; set; }
        public string CardNumber { get; set; }
        public List<Film> purchasedFilms { get; set; }
        public Cart customerCart { get; set; }
    }
}
