using BusinessLogic.DB;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Authorize(Roles = "User")]

    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            // create entities
            StorageEntities db = new StorageEntities();
            ForumContext context = new ForumContext();

            // find the user in DB by his name
            var User = db.Users.Where(s => s.User_Login == HttpContext.User.Identity.Name).FirstOrDefault();

            // assemble the userModel
            var userModel = new UserModel();
            userModel.Id = User.User_ID;
            userModel.Email = User.User_Email;
            userModel.Login = User.User_Login;
            userModel.Password = User.User_Password;

            // we get the roles by user's ID
            var uroles = db.UserRoles.Where(s => s.User_ID == User.User_ID).ToList();

            // collect all roles from the user
            List<RoleModel> roles = new List<RoleModel>();
            foreach (var entry in uroles)
            {
                // assemble roleModel
                RoleModel roleModel = new RoleModel();
                roleModel.Role_ID = entry.Role.Role_ID;
                roleModel.Role_Name = entry.Role.Role_Name;
                // add to the List
                roles.Add(roleModel);
            }

            // pass assembled Data
            context.uRole = roles;
            context.uData = userModel;

            return View(context);
        }
    }
}