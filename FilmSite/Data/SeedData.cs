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
                    new Film() { Name = "Человек-паук (2001)", ShortDescription = "хорошое кинцо", Img = "/img/spider_man1.jpg", Video = "/video/Spider_Man1.mp4" },
                    new Film() { Name = "Человек-паук 2 (2004)", ShortDescription = "лучший фильм", Img = "/img/spider_man2.jpg", Video = "/video/Spider_Man2.mp4" },
                    new Film() { Name = "Человек-паук 3 (2007)", ShortDescription = "ну такое", Img = "/img/spider_man3.jpg", Video = "/video/Spider_Man3.mp4" }
                    //new Film() { Name = "", ShortDescription = "" },
                    //new Film() { },
                    //new Film() { }
                );
            }
            context.SaveChanges();

            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User() { Name = "Admin", Password = "Admin" }
                    );
            }


            context.SaveChanges();
        }
            
    }
}
