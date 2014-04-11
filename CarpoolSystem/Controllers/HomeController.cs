using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarpoolSystem.Services;

namespace CarpoolSystem.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Event()
        {
            if (isLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Event(Models.EventModel userEvent)
        {


            if (ModelState.IsValid)
            {

                DatabaseManager.dbInteraction dbManager = new DatabaseManager.dbInteraction();
                    
                dbManager.createEvent(userEvent.Title, userEvent.StartingAddress, userEvent.StartingCity,
                    userEvent.StartingState, userEvent.DestAddress, userEvent.DestCity,
                    userEvent.DestState, userEvent.StartingTime, userEvent.EndingTime,
                    userEvent.EventInfo, userEvent.Days);

             

                dbManager.newCar(userEvent.CarMake, userEvent.CarModel, userEvent.CarColor,
                    userEvent.CarYear, userEvent.TotalSeats);


                //dbManager.newDriver(User.Identity.Name);

                return RedirectToAction("EventDisplay", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Event Data is incorrect.");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EventDisplay()
        {
            string currentUser = User.Identity.Name;


            //DatabaseManager.dbInteraction dbManager = new DatabaseManager.dbInteraction();

            //var user = dbManager.getUserByName(currentUser);
            //var driver = dbManager.getDriverByUserId(user.FirstOrDefault().UserId);

            //var lastDriverId = dbManager.getLastDriverId(user.FirstOrDefault().UserId);
            //var lastEventId = dbManager.getLastDriverEventId(user.FirstOrDefault().UserId);

            //var car = dbManager.getCarByDriverId(lastDriverId);
            //var events = dbManager.getEventByEventId(lastEventId);


            var model = new Models.EventDisplayModel();
            //model.CarSearch = (IEnumerable<CarpoolSystem.Car>)car;
            //model.EventSearch = (IEnumerable<CarpoolSystem.Event>)events;

            return View(model);
 
        }

        [HttpGet]
        public ActionResult MainPage()
        {
            if (isLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }

           return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Search()
        {
            if (isLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [HttpPost]
        public ActionResult SearchResults(Models.SearchModel search)
        {
            // this method searches site by starting state or by user
            using (var db = new MainDbEntities())
            {
                IEnumerable<Event> EventList;
                IEnumerable<User> UserList;
                // if radio button is true, then we're searching by Starting state
                if (search.StartingState != null && search.radioButton == true)
                {
                    //EventList = db.Events.Where(c => c.StartingState == search.StartingState).ToList();
                    //ViewData["EventResults"] = EventList;
                    return PartialView("_SearchEvent");
                }
                // if radio button is false, then we're searching by user
                else if (search.UserName != null && search.radioButton == false)
                {
                    //UserList = db.Users.Where(c => c.UserName == search.UserName).ToList();
                    //ViewData["UserResults"] = UserList;
                    return PartialView("_SearchUser");
                }
                else
                {
                    return View();
                }
            }
        }
        public ActionResult SuccessfulReg()
        {
            if (isLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        // returns true if user is logged in, false otherwise
        public bool isLoggedIn()
        {
            bool isLoggedIn = false;
            string currentlyLoggedInUser = User.Identity.Name;
            if (currentlyLoggedInUser.Length == 0)
            {
                isLoggedIn = true;
            }
            return isLoggedIn;
        }

    }
}
