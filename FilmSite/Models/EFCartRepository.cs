using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSite.Models
{
    public class EFCartRepository : ICartRepository
    {
        private ApplicationDbContext context;
        public EFCartRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Cart> Carts => context.Carts;
    }
}
