using FilmSite.Data.Interfaces;
using FilmSite.Data.Models;
using FilmSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSite.Data.Repository
{
    public class EFCommentRepository : ICommentRepository 
    {
        private ApplicationDbContext context;
        public EFCommentRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Comment> Comments => context.Comments;

    }
}
