using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSite.Models
{
    public class EFFilmRepository : IFilmRepository
    {
        private ApplicationDbContext context;
        public EFFilmRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Film> Films => context.Films;
    }
}
