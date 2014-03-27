using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

                    return RedirectToAction("EventDisplay", "Home");
                }
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
            using (var db = new MainDbEntities())
            {
                var user = db.Users.FirstOrDefault(c => c.UserName == currentUser);
                var driver = db.Drivers.Where(c => c.UserId == user.UserId).ToList();

                var lastDriverId = 0;
                var lastDriverEventId = 0;
                for (int i = 0; i < driver.Count(); i++)
                {
                      lastDriverId = driver[i].DriverId;
                   // lastDriverEventId = driver.g
                    lastDriverEventId = driver[i].EventId;
                }

                var car = db.Cars.Where(c => c.CarId == lastDriverId).ToList();
                var events = db.Events.Where(c => c.EventId == lastDriverEventId).ToList();

                var model = new Models.EventDisplayModel();
                model.CarSearch = (IEnumerable<CarpoolSystem.Car>)car;
                model.EventSearch = (IEnumerable<CarpoolSystem.Event>)events;

                return View(model);
            }     
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
            Models.SearchModel search = new Models.SearchModel();
            search.StartingState = "pick a state";

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

                List<Event> AllEvents = new List<Event>();
                // if the input is for a starting and ending location
                if (search.StartingState != null && search.DestState != null)
                {
                    IEnumerable<Event> StartToDest = db.Events.Where(c => c.StartingState == search.StartingState
                                                                        && c.DestState == search.DestState).ToList();
                    ViewData["EventResults"] = StartToDest;
                }
                //If one or either of the fields are null, just return what's in start or end queries
                else
                {
                    //either the startlist or Dest list will be populated, not both
                    IEnumerable<Event> StartList;
                    StartList = db.Events.Where(c => c.StartingState == search.StartingState).ToList();

                    IEnumerable<Event> DestList;
                    DestList = db.Events.Where(c => c.DestState == search.DestState).ToList();

                    foreach (var item in StartList)
                    {
                        AllEvents.Add(item);
                    }

                    foreach (var item in DestList)
                    {

                        if (StartList.FirstOrDefault(c => c.EventId == item.EventId) == null)
                        {
                            AllEvents.Add(item);
                        }
                    }

                    ViewData["EventResults"] = AllEvents;
                }
                return PartialView("_SearchEvent");
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
