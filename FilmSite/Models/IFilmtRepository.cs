using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSite.Models
{
    public interface IFilmRepository 
    {
        IQueryable<Film> Films { get; }
    }
}
