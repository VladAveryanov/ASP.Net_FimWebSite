using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSite.Models
{
    public interface IUserRepository
    {
        public IQueryable<User> Users { get; }
    }
}
