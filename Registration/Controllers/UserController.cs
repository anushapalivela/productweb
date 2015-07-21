using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        //public ActionResult Index()
        //{
        //    return View();
        //}


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            { 
                CatalogEntities dc=new CatalogEntities();
                dc.Users.Add(user);
                dc.SaveChanges();
                ModelState.Clear();
                user = null;
                ViewBag.Message = "Registration done successfully";
           }
            return View(user);
        }

    }
}