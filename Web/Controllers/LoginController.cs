using BusinessLogic.DB;
using Domain;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            StorageEntities db = new StorageEntities();
            bool IsValidUser = db.Users.Any(user => user.User_Login.ToLower() ==
             model.UserLogin && user.User_Password == model.Password);
            if (IsValidUser)
            {
                // get the users email
                User user = db.Users.Where(tempik => tempik.User_Login == model.UserLogin).FirstOrDefault();
                // concatenate the user Data
                string userData = string.Format("{0}|{1}|{2}", model.UserLogin, model.Password, user.User_Email);
                // create a ticket that expires after N period of time
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.UserLogin, DateTime.Now, DateTime.Now.AddHours(1), false, userData);
                // setting authorization 
                FormsAuthentication.SetAuthCookie(model.UserLogin, false);
                // encrypting the ticket
                string encTicket = FormsAuthentication.Encrypt(ticket);
                // creating http cookie
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                // adding the cookie to the collection
                Response.Cookies.Add(cookie);

                return RedirectToAction("Index", "Home");
            }
            //ModelState.AddModelError("", "invalid Username or Password");
            return View();
        }

        [HttpGet]
        public ViewResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(UserModel ulog)
        {
            StorageEntities db = new StorageEntities();
            User tempUser = db.Users.Where(model => model.User_Login == ulog.Login || model.User_Login == ulog.Email).FirstOrDefault();
            if (tempUser == null)
            {
                // creating user 
                User user = new User();
                user.User_Login = ulog.Login;
                user.User_Password = ulog.Password;
                user.User_Email = ulog.Email;

                // saving user
                db.Users.Add(user);

                // assigning default role to the user
                UserRole role = new UserRole();
                role.User_ID = user.User_ID;
                role.Role_ID = 2;
                db.UserRoles.Add(role);

                // save it
                db.SaveChanges();
                return RedirectToAction("Login", "Login", ulog);
            }
            return View("login", ulog);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}