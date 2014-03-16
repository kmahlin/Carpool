using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarpoolSystem.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Event()
        {
            string currentlyLoggedInUser = User.Identity.Name;
            if (currentlyLoggedInUser.Length == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Search()
        {
            string currentlyLoggedInUser = User.Identity.Name;
            if (currentlyLoggedInUser.Length == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public ActionResult SuccessfulReg()
        {
            return View();
        }

    }
}
