using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSite.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
            .GetRequiredService<ApplicationDbContext>();
            
            context.Database.Migrate();

            if (!context.Films.Any())
            {
                context.Films.AddRange(
                    new Film() { Name = "Человек-паук (2001)", Description = "хорошое кинцо", Img = "/img/spider_man1.jpg" },
                    new Film() { Name = "Человек-паук 2 (2004)", Description = "лучший фильм", Img = "/img/spider_man2.jpg" },
                    new Film() { Name = "Человек-паук 3 (2007)", Description = "ну такое", Img = "/img/spider_man3.jpg" }
                );
            }
            context.SaveChanges();
        }
            
    }
}
