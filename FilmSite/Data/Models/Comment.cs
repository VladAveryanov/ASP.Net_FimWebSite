using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSite.Data.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string CommentText { get; set; }
        public string CommentTime { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public int FilmID { get; set; }
    }
}
