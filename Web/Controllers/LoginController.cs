using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Registration()
        {
            return View();
        }
        //public ViewResult Registration(FormCollection values)
        //{
        //    ViewBag.User = values["user"];
        //    ViewBag.Email = values["email"];
        //    ViewBag.Password = values["password"];
        //    return View("login");
        //    //return RedirectToAction("Login", "Login");
        //}
        [HttpPost]
        public ActionResult Registration(UserLogin ulog)
        {
            //return View("login",ulog);
            return RedirectToAction("Login", "Login",ulog);
        }

    }
}