using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSite.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public string UserName { get; set; }
        public List<Film> Films { get; set; }

    }
}
