using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Uppgift4Interaktiva.Models;

namespace Uppgift4Interaktiva.Controllers
{
    public class LogInNowController : Controller
    {
        // GET: LogInNow
        public ActionResult Index()
        {
            string btnClick = Request["loginBtn"];
            if (btnClick == "Login")
            {
                string userName = Request["userName"];
                string password = Request[ "password"];
                Uppgift4EntitiesLogIn db = new Uppgift4EntitiesLogIn();
                var userLogin = (from a in db.Users where a.UserName == userName && a.Password == password select a).FirstOrDefault();

                if (userLogin != null)
                {
                    Session["userName"] = userLogin.UserName;
                    Session["passId"] = userLogin.UserId;
                    return RedirectToAction("index", "TvPrograms");
                }
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }

    }
}