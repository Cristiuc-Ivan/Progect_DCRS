using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{

    public class ForumController : Controller
    {
        // GET: Forum
        public ActionResult Index()
        {
            return View();
        }


 //       [HttpPost]
 //       public class ActionResult Create()
 //       {
 //           return View();
 //       }
    }
}