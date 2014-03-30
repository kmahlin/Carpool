﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.InteropServices;
using CarpoolSystem.Managers;

namespace CarpoolSystem.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Event()
        {
            if (!isLoggedIn())
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
                DatabaseManager dbManager = new DatabaseManager();


                //TODO: error handeling, roll back inserts on fail
                //possible try catch block that says if any of these methods fail
                // remove the previous inserts
                dbManager.createEvent(userEvent.Title, userEvent.StartingAddress, userEvent.StartingCity,
                    userEvent.StartingState,userEvent.DestAddress,userEvent.DestCity,
                    userEvent.DestState,userEvent.StartingTime,userEvent.EndingTime,
                    userEvent.EventInfo,userEvent.Days,userEvent.TypeRadio,userEvent.EventStartDate,
                    userEvent.EventEndDate);

                dbManager.newCar(userEvent.CarMake,userEvent.CarModel,userEvent.CarColor,
                    userEvent.CarYear,userEvent.TotalSeats);

 
                dbManager.newDriver(User.Identity.Name);


                // using -1 as a check to indicated an event was just created
                return RedirectToAction("EventDisplay", "Home", new { id = -1 });
                
            }
            else
            {
                ModelState.AddModelError("", "Event Data is incorrect.");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EventDisplay(int id, string message)
        {
            string currentUser = User.Identity.Name;

            List<CarpoolSystem.Car> car = new List<CarpoolSystem.Car>();
            List<CarpoolSystem.Event> events = new List<CarpoolSystem.Event>();
            List<CarpoolSystem.User> usersPassengers = new List<CarpoolSystem.User>();
            //List<CarpoolSystem.Driver> eventDriver = new List<CarpoolSystem.Driver>();

            DatabaseManager dbManager = new DatabaseManager();

            //when id is negative, we are displaying a newly created event
            //otherwise (else) it's an event search
            if (id < 0 )
            {
                var userInfo = dbManager.getUserByName(currentUser);
                var driverId = dbManager.getLastDriverId(userInfo.First().UserId);
                var eventId = dbManager.getLastDriverEventId(userInfo.First().UserId);

                //eventDriver = dbManager.getDriverByUserId(userInfo.FirstOrDefault().UserId);

                car = dbManager.getCarByDriverId(driverId);
                events = dbManager.getEventByEventId(eventId);
            }
            // displays the called event result based on id
            else
            {
                var eventDisplay = dbManager.getEventByEventId(id);
                var driver = dbManager.getDriverByEventId(eventDisplay.First().EventId);
                var carlist = dbManager.getCarByDriverId(driver.First().DriverId);


                //eventDriver = dbManager.getDriverByEventId(eventDisplay.FirstOrDefault().EventId);
                usersPassengers = dbManager.getPassengerNames(id);
                
                car.Add(carlist.First());
                events.Add(eventDisplay.First());
            }


            var model = new Models.EventDisplayModel();
            model.CarSearch = (IEnumerable<CarpoolSystem.Car>)car;
            model.EventSearch = (IEnumerable<CarpoolSystem.Event>)events;
            model.UserSearch = (IEnumerable<CarpoolSystem.User>)usersPassengers;
            //model.DriverSearch = (IEnumerable<CarpoolSystem.User>)eventDriver;

            ViewData["Message"] = message;

            return View(model);
        }
        public ActionResult JoinEvent(int id)
        {
            DatabaseManager dbManager = new DatabaseManager();
            string message = null;
            string currentUser = User.Identity.Name;

            if (dbManager.eventMemberCheck(currentUser, id))
            {
                // user is already a member of event
                // don't add to passenger list

                message = "You're already a member of this event!";
            }
            else
            {
                
                if (dbManager.eventSeatCheck(id))
                {
                    // there is a free seat, add user to carpool
                    dbManager.newPassenger(currentUser, id);

                    message = "You've Joined the Event!";
                }
            }
            return RedirectToAction("EventDisplay", "Home", new { id = id, message });

        }

        [HttpGet]
        public ActionResult UserEventDisplay()
        {

            string currentUser = User.Identity.Name;

            if (!isLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }


            DatabaseManager dbManager = new DatabaseManager();

            var userInfo = dbManager.getUserByName(currentUser);
            var eventList = dbManager.getAllEventsByUserId(userInfo.First().UserId);

            return View(eventList);
        }

        public ActionResult RemoveCarpool(int id)
        {
            DatabaseManager dbManager = new DatabaseManager();
            dbManager.removeCarpoolEvent(id);
            dbManager.saveChanges();


            return RedirectToAction("UserEventDisplay", "Home");
        }
        [HttpGet]
        public ActionResult MainPage(string message)
        {
            if (!isLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }

            ViewData["Message"] = message;

           return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Search()
        {
            if (!isLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }

            //Models.SearchModel search = new Models.SearchModel();


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

        // returns true if user is logged in, false otherwise
        public bool isLoggedIn()
        {
            bool isLoggedIn = false;
            string currentlyLoggedInUser = User.Identity.Name;
            if (currentlyLoggedInUser.Length == 0)
            {
                isLoggedIn = false;
            }
            else
            {
                isLoggedIn = true;
            }
            return isLoggedIn;
        }

    }
}
