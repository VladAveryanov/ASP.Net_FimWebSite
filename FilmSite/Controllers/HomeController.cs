using FilmSite.Data.Models;
using FilmSite.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FilmSite.Controllers
{
    public class HomeController : Controller
    {
        
        private IFilmRepository filmRepository;

        private IUserRepository userRepository;

        private ApplicationDbContext _context;

        public HomeController(IFilmRepository repo, IUserRepository user, ApplicationDbContext context)
        {
            filmRepository = repo;
            userRepository = user;
            _context = context;
        }
        public ViewResult Index()
        {
            return View("MainPage", filmRepository.Films);
        }
        public ViewResult FilmToWatch(int id)
        {
            return View("FilmPage",filmRepository.Films.Where(x => x.FilmID==id));
        }

        public ViewResult Pur()
        {
            return View("PurchasedFilms");
        }
        public ViewResult PurchasedFilms(User user)
        {
            if (user != null)
                return View("PurchasedFilms");
            else
                return View("AuthorizationError");
        }

        [HttpGet]
        public ViewResult Enter()
        {
            return View("Enter");
        }

        [HttpPost]
        public ViewResult Enter(User user)
        {
            foreach(var e in userRepository.Users)
            {
                if (user.Name == e.Name && user.Password == e.Password)
                {
                    CurrentUser.UserName = user.Name;
                    CurrentUser.Online = true;
                    return View("test_view1");
                }
                    
            }
            return View("AuthorizationError");
        }

        
        public ViewResult Exit()
        {
            CurrentUser.Online = false;
            return View("MainPage", filmRepository.Films);
        }


        [HttpGet]
        public ViewResult Registration()
        {
            return View("Registration");
        }

        [HttpPost]
        public ViewResult Registration(User user)
        {
            foreach (var e in userRepository.Users)
            {
                if (user.Name == e.Name)
                    return View("test_view2");
            }
            
            _context.Users.Add(user);
            _context.SaveChanges();
            
            
            return View("test_view1");
        }

        [HttpPost]
        public ViewResult Search(string searchString)
        {
            var list = new List<Film>();
            foreach(var e in filmRepository.Films)
            {
                if (e.Name.Contains(searchString))
                {
                    list.Add(e);
                    //return View("SearchResult", filmRepository.Films.Where(x => x.FilmID == e.FilmID));
                }
            }
            if (list.Count > 0)
                return View("SearchResult", list);
            else
                return View("test_view2");
        }

    }
}
