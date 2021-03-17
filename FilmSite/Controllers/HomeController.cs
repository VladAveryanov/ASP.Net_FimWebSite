using FilmSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FilmSite.Controllers
{
    public class HomeController : Controller
    {
        private IFilmRepository filmRepository;

        private IUserRepository userRepository;

        public HomeController(IFilmRepository repo, IUserRepository user)
        {
            filmRepository = repo;
            userRepository = user;
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

        public ViewResult Enter()
        {
            return View("Enter", userRepository.Users);
        }

    }
}
