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

        [HttpGet]
        public ActionResult Event()
        {
            string currentlyLoggedInUser = User.Identity.Name;
            if (currentlyLoggedInUser.Length == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Event(Models.EventModel userEvent)
        {

            //for debugging
            var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors })
                    .ToArray();

            

            if (ModelState.IsValid)
            {
                using (var db = new MainDbEntities())
                {
                    //Need a user/car/event before you can have a driver

                    //Event Section
                    var newEvent = db.Events.CreateObject();

                    newEvent.Title = userEvent.Title;

                    newEvent.StartingAddress = userEvent.StartingAddress;
                    newEvent.StartingCity = userEvent.StartingCity;
                    newEvent.StartingState = userEvent.StartingState;

                    newEvent.EndingAddress = userEvent.DestAddress;
                    newEvent.DestCity = userEvent.DestCity;
                    newEvent.DestState = userEvent.DestState;

                    // these datetimes need to be changed to user datetimes
                    newEvent.StartingTime = userEvent.StartingTime;
                    newEvent.EndingTime = userEvent.EndingTime;

                    newEvent.EventInfo = userEvent.EventInfo;
                    newEvent.Days = userEvent.Days;

                    //car Section
                    var newCar = db.Cars.CreateObject();
                    newCar.CarMake = userEvent.CarColor;
                    newCar.CarModel = userEvent.CarModel;
                    newCar.CarColor = userEvent.CarColor;
                    newCar.CarYear = userEvent.CarYear;
                    newCar.TotalSeats = userEvent.TotalSeats;

                    //TODO: In the view,
                    //expcitly state that there are x number of seats for passenger
                    newCar.SeatsLeft = userEvent.TotalSeats;


                    db.Events.AddObject(newEvent);
                    db.Cars.AddObject(newCar);

                    db.SaveChanges();


                    // Driver Section
                    //create add id's to driver table
                    var driver = db.Drivers.CreateObject();
                    driver.CarId = newCar.CarId;
                    driver.EventId = newEvent.EventId;

                    //get current logged in user
                    string currentUser = User.Identity.Name;
                    User sysUser = db.Users.FirstOrDefault(m => m.UserName == currentUser);
                    driver.UserId = sysUser.UserId;


                    db.Drivers.AddObject(driver);
                    db.SaveChanges();

                    return RedirectToAction("Event", "Home");
                }

            }
            else
            {
                ModelState.AddModelError("", "Event Data is incorrect.");
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
            string currentlyLoggedInUser = User.Identity.Name;
            if (currentlyLoggedInUser.Length == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Search(Models.SearchModel search)
        {
            using (var db = new MainDbEntities())
            {
                var results = new Models.EventSearchModel();

                //TODO: Return search query to view


                //results =
                //(
                //    from p in db.Events
                //    where (p.DestState == search.StartingState) && (p.DestCity == search.StartingCity)
                //    select p
                //).ToList();

                ViewData["results"] = results;

                return View();
                //return PartialView("_SearchByStateCity");
            }
        }

        public ActionResult SuccessfulReg()
        {
            return View();
        }

    }
}
