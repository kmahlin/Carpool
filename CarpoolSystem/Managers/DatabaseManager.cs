using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarpoolSystem.Managers
{
    public class DatabaseManager
    {
        MainDbEntities db = new MainDbEntities();

        

        public List<CarpoolSystem.User> getUserByName(string userName)
        {
            var user = db.Users.Where(c => c.UserName == userName).ToList();

            return user;
        }

        public List<CarpoolSystem.Car> getCarList(int driverId)
        {

            var carList = db.Cars.Where(c => c.CarId == driverId).ToList();

            return carList;
        }

        public List<CarpoolSystem.Event> getEventList(int eventId)
        {

            var eventList = db.Events.Where(c => c.EventId == eventId).ToList();

            return eventList;
        }

        public List<CarpoolSystem.Driver> getDriverList(int eventId)
        {

            var driverList = db.Drivers.Where(c => c.EventId == eventId).ToList();

            return driverList;
        }

        public int getLastDriverId(int userId)
        {

            var driver = db.Drivers.Where(c => c.UserId == userId).ToList();

            var lastDriverId = 0;
            for (int i = 0; i < driver.Count(); i++)
            {
                lastDriverId = driver[i].CarId;
            }

            return lastDriverId;

        }

        public int getLastDriverEventId(int userId)
        {

            var driver = db.Drivers.Where(c => c.UserId == userId).ToList();

            var lastDriverEventId = 0;
            for (int i = 0; i < driver.Count(); i++)
            {
                lastDriverEventId = driver[i].EventId;
            }

            return lastDriverEventId;

        }

        public int latestEventId { get; set; }
        public int latestCarId  { get; set; }

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

        public void saveChanges()
        {
            db.SaveChanges();
        }

    }
}