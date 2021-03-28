using FilmSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSite.Data.Interfaces
{
    public interface ICommentRepository 
    {
        IQueryable<Comment> Comments { get; }
    }
}
