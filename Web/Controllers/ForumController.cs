using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{

    public class ForumController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            return View();
        }

        [HttpGet]
        public ActionResult LayoutComments()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult LayoutComments(LoginModel model)
        {
            return View();
        }
    }
}