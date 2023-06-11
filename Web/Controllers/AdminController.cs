using BusinessLogic.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public ViewResult Index()
        {
            StorageEntities db = new StorageEntities();
            return View(db.Users);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User us)
        {
            if (ModelState.IsValid)
            {
                StorageEntities db = new StorageEntities();
                us.User_Picture = "aaaa";
                db.Users.Add(us);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Invalid data");
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            StorageEntities db = new StorageEntities();
            User model = db.Users.Find(id);
            if (model != null)
            {
                List<UserRole> role = db.UserRoles.Where(s => s.User_ID == id).ToList();
                foreach (var item in role)
                {
                    db.UserRoles.Remove(item);
                }
                db.Users.Remove(model);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            StorageEntities db = new StorageEntities();
            User us = db.Users.Find(id);
            ViewBag.isEdit = true;
            return View("Create", us);
        }

        [HttpPost]
        public ActionResult Edit(User us)
        {
            StorageEntities db = new StorageEntities();
            db.Entry<User>(us).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}