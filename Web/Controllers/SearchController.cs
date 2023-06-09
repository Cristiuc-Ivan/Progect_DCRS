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
        // GET: Search
        [HttpGet]
        public ActionResult Actors(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Actors(TestModel test)
        {
            var a = 5;
            // Access the data sent from JavaScript

            return View();
        }
    }
}