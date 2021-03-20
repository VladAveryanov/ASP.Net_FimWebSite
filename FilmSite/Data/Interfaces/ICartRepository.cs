using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSite.Models
{
    interface ICartRepository
    {
        public IQueryable<Cart> Carts { get; }
    }
}
