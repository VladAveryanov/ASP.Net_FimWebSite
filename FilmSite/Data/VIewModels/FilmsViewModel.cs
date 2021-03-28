using FilmSite.Data.Models;
using FilmSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSite.Data.VIewModels
{
    public class FilmsViewModel
    {
        public IQueryable<Film> Films { get; set; }
        public IQueryable<Comment> Comments { get; set; }
        public IQueryable<User> Users { get; set; }
    }
}
