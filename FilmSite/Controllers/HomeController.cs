using FilmSite.Data.Interfaces;
using FilmSite.Data.Models;
using FilmSite.Data.VIewModels;
using FilmSite.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FilmSite.Controllers
{
    public class HomeController : Controller
    {
        
        private IFilmRepository filmRepository;

        private IUserRepository userRepository;

        private ICommentRepository commentRepository;

        private ApplicationDbContext _context;

        public HomeController(IFilmRepository repo, IUserRepository user, ICommentRepository comment, ApplicationDbContext context)
        {
            filmRepository = repo;
            userRepository = user;
            commentRepository = comment;
            _context = context;
        }
        public ViewResult Index()
        {
            return View("MainPage", filmRepository.Films);
        }

        [HttpGet]
        public ViewResult FilmToWatch(int id)
        {
            FilmsViewModel fvm = new FilmsViewModel()
                { Films = filmRepository.Films.Where(x => x.FilmID == id), Comments = commentRepository.Comments };

            ViewBag.FilmID = fvm.Films.FirstOrDefault().FilmID;
            return View("FilmPage",fvm);
            //return View("FilmPage",filmRepository.Films.Where(x => x.FilmID==id));
        }

        [HttpPost]
        public ViewResult FilmToWatch(Comment cmnt)
        {
            if (CurrentUser.UserName != null)
                cmnt.UserName = CurrentUser.UserName;
            else
                cmnt.UserName = "Debil";

            cmnt.CommentTime = DateTime.Now.ToString();
            cmnt.Dislikes = 0;
            cmnt.Likes = 0;
            
            _context.Comments.Add(cmnt);
            _context.SaveChanges();

            FilmsViewModel fvm = new FilmsViewModel()
            { Films = filmRepository.Films.Where(x => x.FilmID == cmnt.FilmID), Comments = commentRepository.Comments };
            return View("FilmPage", fvm);
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
