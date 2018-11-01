using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Uppgift4Interaktiva.Models;

namespace Uppgift4Interaktiva.Controllers
{
    public class LoginController : Controller
    {

        // GET: Login

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserProfile objUser)
        {
            if (ModelState.IsValid)
            {
                
                using(Uppgift4Entities1 dbl = new Uppgift4Entities1())
                {
                    var result = dbl.UserProfiles.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (result != null)
                    {
                        Session["UserID"] = result.UserId.ToString();
                        Session["UserName"] = result.UserName.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}