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
        StorageEntities db = new StorageEntities();
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
        public ActionResult ActorAdd(string ActorName, string ActorKnownFor, string ActorPic, ActorsModel ActorDATA)
        {
            Actor actor = new Actor
            {
                Actor_Name = ActorName,
                Actor_Picture = ActorPic,
            };

            var User = db.Users
                .Where(s => s.User_Login == HttpContext.User.Identity.Name)
                .FirstOrDefault();

            if (actor.Actor_ID == 0 && db.Actors
                .Where(m => m.Actor_Name == ActorName)
                .FirstOrDefault() == null)
            {
                db.Actors.Add(actor);
                db.SaveChanges();
            }

            var aaa = db.Actors
                .Where(m => m.Actor_Name == ActorName)
                .FirstOrDefault();

            var asdasda = db.UserActors
                .Where(m => m.Actor_ID == aaa.Actor_ID && m.User_ID == User.User_ID)
                .FirstOrDefault();

            if (asdasda == null)
            {
                Actor actualActor = db.Actors
                    .Where(d => d.Actor_Name == ActorName)
                    .FirstOrDefault();

                UserActor userActor = new UserActor
                {
                    User_ID = User.User_ID,
                    Actor_ID = actualActor.Actor_ID
                };
                db.UserActors.Add(userActor);
                db.SaveChanges();
            }

            return RedirectToAction("Actors", ActorDATA);
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
            Movie movie = new Movie
            {
                Movie_Name = MovieName,
                Movie_Picture = MoviePic,
            };

            var User = db.Users
                .Where(s => s.User_Login == HttpContext.User.Identity.Name)
                .FirstOrDefault();

            if (movie.Movie_ID == 0 && db.Movies
                .Where(m => m.Movie_Name == MovieName)
                .FirstOrDefault() == null)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
            }

            var aaa = db.Movies
                .Where(m => m.Movie_Name == MovieName)
                .FirstOrDefault();

            var asdasda = db.UserMovies
                .Where(m => m.Movie_ID == aaa.Movie_ID && m.User_ID == User.User_ID)
                .FirstOrDefault();

            if (asdasda == null)
            {
                Movie actualMovie = db.Movies
                    .Where(d => d.Movie_Name == movie.Movie_Name)
                    .FirstOrDefault();

                UserMovie userMovie = new UserMovie
                {
                    User_ID = User.User_ID,
                    Movie_ID = actualMovie.Movie_ID
                };
                db.UserMovies.Add(userMovie);
                db.SaveChanges();
            }

            return RedirectToAction("Movies", data);
        }
    }
}