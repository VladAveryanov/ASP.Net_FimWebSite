using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSite.Data.Models
{
    public static class CurrentUser
    {
        public static string UserName { get; set; }

        public static bool Online { get; set; }
    }
}
