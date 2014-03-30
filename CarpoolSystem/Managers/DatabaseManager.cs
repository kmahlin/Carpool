using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarpoolSystem.Managers
{
    public class DatabaseManager
    {
        MainDbEntities db = new MainDbEntities();


        public int latestEventId { get; set; }
        public int latestCarId { get; set; }

        #region MemberCheck
        public bool eventMemberCheck(string userName, int eventId)
        {
            bool isMember = false;

            var user = getUserByName(userName);

            var passenger = getPassengerByUserId(user.First().UserId);
            var driver = getDriverByUserId(user.First().UserId);


            if (passenger != null)
            {
                foreach (var item in passenger)
                {
                    if (item.EventId == eventId)
                    {
                        isMember = true;
                        break;
                    }
                }
            }

            if (driver != null && isMember == false)
            {
                foreach (var item in driver)
                {
                    if (item.EventId == eventId)
                    {
                        isMember = true;
                        break;
                    }
                }
            }

            return isMember;
        }

        //Checks to see if there is a free seat in the car for the event
        public bool eventSeatCheck(int eventId)
        {
            bool isSeatOpen = false;

            var driverInfo = getDriverByEventId(eventId);
            var carInfo = getCarByDriverId(driverInfo.First().DriverId);
            int carSeatsLeft = carInfo.First().SeatsLeft;

            if (carSeatsLeft > 0)
            {
                isSeatOpen = true;
            }

            return isSeatOpen;

        }
        #endregion

        #region Create

        public void createEvent(string title, string startingAddress, string startingCity, string startingState, string destAddress,
            string destCity, string destState, string startingTime, string EndingTime, string eventInfo, string days, bool type,
            string eventStartDate, string eventEndDate)
        {
            var newEvent = db.Events.CreateObject();

            newEvent.Title = title;

            newEvent.StartingAddress = startingAddress;
            newEvent.StartingCity = startingCity;
            newEvent.StartingState = startingState;

            newEvent.DestAddress = destAddress;
            newEvent.DestCity = destCity;
            newEvent.DestState = destState;

            newEvent.StartingTime = startingTime;
            newEvent.EndingTime = EndingTime;

            newEvent.EventInfo = eventInfo;
            newEvent.Days = days;

            if (type == true)
            {
                //reccurring/commuter is checked
                newEvent.Type = "recurring";
            }
            else
            {
                // one time event is checked
                newEvent.Type = "non-recurring";
            }

            newEvent.EventStartDate = eventStartDate;
            newEvent.EventEndDate = eventEndDate;

            db.Events.AddObject(newEvent);

            saveChanges();

            latestEventId = newEvent.EventId;


        }

        public void newCar(string carMake, string carModel, string carColor, Int32 carYear, Int32 totalSeats)
        {
            var newCar = db.Cars.CreateObject();
            newCar.CarMake = carMake;
            newCar.CarModel = carModel;
            newCar.CarColor = carColor;
            newCar.CarYear = carYear;
            newCar.TotalSeats = totalSeats;

            //TODO: In the view,
            //expcitly state that there are x number of seats for passenger
            newCar.SeatsLeft = totalSeats;

            db.Cars.AddObject(newCar);

            saveChanges();

            latestCarId = newCar.CarId;
        }


        public void newDriver(string userName)
        {
            var driver = db.Drivers.CreateObject();
            driver.CarId = latestCarId;
            driver.EventId = latestEventId;

            driver.UserId = getUserByName(userName).First().UserId;

            db.Drivers.AddObject(driver);

            saveChanges();
        }

        public void newPassenger(string userName, int eventId)
        {
            var passenger = db.Passengers.CreateObject();

            passenger.UserId = getUserByName(userName).First().UserId;
            passenger.EventId = eventId;
            db.Passengers.AddObject(passenger);


            saveChanges();


            //decrement seatsleft on car table based on this new passenger
            var driver = getDriverByEventId(eventId).FirstOrDefault();
            var car = getCarByDriverId(driver.DriverId).FirstOrDefault();
            car.SeatsLeft = car.SeatsLeft - 1;

            saveChanges();
        }


        #endregion

        #region Retrieval



        public List<CarpoolSystem.Profile> getProfilebyProfileId(int id)
        {
            var profile = db.Profiles.Where(c => c.ProfileId == id).ToList();

            return profile;
        }

        public List<CarpoolSystem.User> getUserByProfileId(int id)
        {
            var user = db.Users.Where(c => c.ProfileId == id).ToList();

            return user;
        }

        public List<CarpoolSystem.User> getUserByDriverId(int driverId)
        {
            var driverList = db.Drivers.Where(c => c.DriverId == driverId).ToList();
            int userId = driverList.First().UserId;
            var user = db.Users.Where(c => c.UserId == userId).ToList();

            return user;
        }

        public List<CarpoolSystem.User> getUserByName(string userName)
        {
            var user = db.Users.Where(c => c.UserName == userName).ToList();

            return user;
        }

        public List<CarpoolSystem.Car> getCarByDriverId(int driverId)
        {
            var driverList = db.Drivers.Where(c => c.DriverId == driverId).ToList();
            
            int carId = driverList.First().CarId;
            var carList = db.Cars.Where(c => c.CarId == carId).ToList();

            return carList;
        }

        public List<CarpoolSystem.Event> getEventByEventId(int eventId)
        {

            var eventList = db.Events.Where(c => c.EventId == eventId).ToList();

            return eventList;
        }

        public List<CarpoolSystem.Event> getAllEventsByUserId(int userId)
        {

            //TODO, when passengers are implemented, this will need to pull from passenger table too
            // right now it only takes into account the drive table

            var driverList = db.Drivers.Where(c => c.UserId == userId).ToList();
            List<CarpoolSystem.Event> eventList = new List<CarpoolSystem.Event>();

            foreach (var item in driverList)
            {
                var eventTemp = db.Events.Where(c => c.EventId == item.EventId).ToList();
                eventList.Add(eventTemp.First());

            }

            return eventList;
        }

        public List<CarpoolSystem.Driver> getDriverByEventId(int eventId)
        {

            var driverList = db.Drivers.Where(c => c.EventId == eventId).ToList();

            return driverList;
        }

        public List<CarpoolSystem.User> getPassengerNames(int eventId)
        {
            List<CarpoolSystem.User> users = new List<CarpoolSystem.User>();

            var passengers = getPassengerByEventId(eventId).ToList();
            foreach (var item in passengers)
            {
                var tempPassenger = db.Users.Where(c => c.UserId == item.UserId);
                users.Add(tempPassenger.First());
            }

            return users;
        }

        public List<CarpoolSystem.Passenger> getPassengerByEventId(int eventId)
        {

            var passengerList = db.Passengers.Where(c => c.EventId == eventId).ToList();

            return passengerList;
        }

        public List<CarpoolSystem.Passenger> getPassengerByUserId(int userId)
        {

            var passengerList = db.Passengers.Where(c => c.UserId == userId).ToList();

            return passengerList;
        }

        public List<CarpoolSystem.Driver> getDriverByUserId(int userId)
        {

            var driverList = db.Drivers.Where(c => c.UserId == userId).ToList();

            return driverList;
        }

        public int getLastDriverId(int userId)
        {

            var driver = db.Drivers.Where(c => c.UserId == userId).ToList();

            var lastDriverId = 0;
            
            for (int i = driver.Count() - 1; i < driver.Count(); i++)
            {
                lastDriverId = driver[i].DriverId;
            }

            return lastDriverId;
        }

        public int getLastDriverEventId(int userId)
        {

            var driver = db.Drivers.Where(c => c.UserId == userId).ToList();

            var lastDriverEventId = 0;
            for (int i = driver.Count -1; i < driver.Count(); i++)
            {
                lastDriverEventId = driver[i].EventId;
            }

            return lastDriverEventId;

        }
        #endregion

        #region Update

        public void saveChanges()
        {
            db.SaveChanges();
        }

        #endregion

        #region Destroy

        public void removePassenger(int eventId)
        {
            var passengerRecord = getPassengerByEventId(eventId).FirstOrDefault();
            if (passengerRecord != null)
            {
                db.Passengers.DeleteObject(passengerRecord);
            }

            saveChanges();

            //increment seatsleft on car table based on this new passenger
            var driver = getDriverByEventId(eventId).FirstOrDefault();
            var car = getCarByDriverId(driver.DriverId).FirstOrDefault();
            car.SeatsLeft = car.SeatsLeft - 1;

            saveChanges();
        }

        public void removeCarpoolEvent(int eventId)
        {

            var driverRecord = getDriverByEventId(eventId).FirstOrDefault();
            if (driverRecord != null)
            {
                db.Drivers.DeleteObject(driverRecord);
            }

            var carRecord = getCarByDriverId(driverRecord.DriverId).FirstOrDefault();
            if (carRecord != null)
            {
                db.Cars.DeleteObject(carRecord);
            }

            var passengerRecord = getPassengerByEventId(eventId).FirstOrDefault();
            if (passengerRecord != null)
            {
                db.Passengers.DeleteObject(passengerRecord);
            }

            var EventRecord = getEventByEventId(eventId).FirstOrDefault();
            if (EventRecord != null)
            {
                db.Events.DeleteObject(EventRecord);
            }

        }
        #endregion

    }
}