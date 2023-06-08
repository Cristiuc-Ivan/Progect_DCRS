using BusinessLogic.DB;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class SearchController : Controller
    {
        [HttpPost]
        public ActionResult Actors(ActorsModel data)
        {
            // Process the data
            TempData["data"] = data;

            return Json(new { success = true }); // Return a JSON response indicating success
        }

        [HttpGet]
        public ActionResult Actors()
        {
            ActorsModel manyActors = (ActorsModel)TempData["data"];
            return View(manyActors);
        }


        [HttpPost]
        [Authorize]
        public ActionResult ActorAdd(string ActorName, string ActorKnownFor, string ActorPic, MoviesModel data)
        {
            StorageEntities db = new StorageEntities();
            Actor actor = new Actor
            {
                Actor_Name = ActorName,
                Actor_Picture = ActorPic,
            };
            db.Actors.Add(actor);
            var User = db.Users.Where(s => s.User_Login == HttpContext.User.Identity.Name).FirstOrDefault();

            UserActor userActor = new UserActor
            {
                User_ID = User.User_ID,
                Actor_ID = actor.Actor_ID
            };
            db.UserActors.Add(userActor);
            db.SaveChanges();

            return RedirectToAction("Actors", data);
        }

        [HttpPost]
        public ActionResult Movies(MoviesModel data)
        {
            // Process the data
            TempData["data"] = data;

            return Json(new { success = true }); // Return a JSON response indicating success
        }

        [HttpGet]
        public ActionResult Movies()
        {
            MoviesModel manyMovies = (MoviesModel)TempData["data"];
            TempData["data"] = manyMovies;
            return View(manyMovies);
        }

        [HttpPost]
        [Authorize]
        public ActionResult MovieAdd(string MovieName, string MovieGenres, string MoviePic, MoviesModel data)
        {
            StorageEntities db = new StorageEntities();
            Movie movie = new Movie
            {
                Movie_Name = MovieName,
                Movie_Picture = MoviePic,
            };
            db.Movies.Add(movie);
            var User = db.Users.Where(s => s.User_Login == HttpContext.User.Identity.Name).FirstOrDefault();

            UserMovie userMovie = new UserMovie
            {
                User_ID = User.User_ID,
                Movie_ID = movie.Movie_ID
            };
            db.UserMovies.Add(userMovie);
            db.SaveChanges();

            return RedirectToAction("Movies", data);
        }
    }
}