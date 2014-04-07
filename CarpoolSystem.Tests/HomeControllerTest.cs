using Moq;
using System;
using System.Web.Mvc;
using CarpoolSystem.Models;
using CarpoolSystem.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace CarpoolSystem.Tests
{

    [TestClass()]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Test_Event_ModelState_IsValid()
        {

            //Arrange 
            HomeController controller = new HomeController();

            EventModel model = new EventModel
            {
                 Title = "Event1",
                 StartingAddress = "TheBestStreet",
                 StartingCity = "TheBestCity",
                 StartingState = "THeBestSTate",
                 DestAddress = "TheWorstStreet",
                 DestCity = "TheWorstCity",
                 DestState = "TheWorstState",
                 StartingTime = "10:00AM",
                 EndingTime = "5:00PM",
                 EventInfo = "CARPOOOOOOOOOLLLLLL",
                 Days = "MWFTS",
                 CarMake = "Ford",
                 CarModel = "F150",
                 CarYear = 2015,
                 CarColor = "White",
                 TotalSeats = 5,
            };


            //Act

            controller.Event(model);

                //controller .ModelState.AddModelError("key","error message");
            //Assert

            Assert.IsTrue(controller.ViewData.ModelState.Count == 0, "ModelState is Valid");
        }









        //[TestClass()]
        //public void Test_Retriving_Event_Data_From_Database()
        //{

        //    //Arrange 
        //    var mockSet = new Mock<MainDbEntities>();


        //    //Act


        //    //Assert
        //}


    }
}
