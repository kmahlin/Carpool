using Moq;
using System;
using System.Web.Mvc;
using CarpoolSystem.Models;
using CarpoolSystem.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Collections.Specialized;
using System.Globalization;

namespace CarpoolSystem.Tests
{

    [TestClass()]
    public class HomeControllerTest
    { 

        [TestMethod]
        public void Test_Event_ModelState_Invalid()
        {
            //Arrange 
            var controller = new HomeController();
            controller.ViewData.ModelState.Clear();

            var model = new EventModel();

            var modelBinder = new ModelBindingContext()
            {
                ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(
                                  () => model, model.GetType()),
                ValueProvider = new NameValueCollectionValueProvider(
                                    new NameValueCollection(), CultureInfo.InvariantCulture)
            };


            //Act
            var binder = new DefaultModelBinder().BindModel(
                 new ControllerContext(), modelBinder);
            controller.ModelState.Clear();
            controller.ModelState.Merge(modelBinder.ModelState);

            ViewResult result = (ViewResult)controller.Event(model);

            //Assert
            Assert.IsTrue(!result.ViewData.ModelState.IsValid);

        }

        [TestMethod]
        public void Test_Event_ModelState_valid()
        {

            //Arrange 
            var controller = MockLoggedInUser("SomeUser");
            controller.ViewData.ModelState.Clear();

            var model = new EventModel()
            {
                Title = "Event1",
                StartingAddress = "Street1",
                StartingCity = "Lincoln",
                StartingState = "Nebraska",
                DestAddress = "Street2",
                DestCity = "Omaha",
                DestState = "Nebraska",
                StartingTime = " 10:00Am",
                EndingTime = "5:00pm",
                EventInfo = "stuff and stuff",
                Days = "MWFT",
                CarMake = "Ford",
                CarModel = "F150",
                CarYear = 2015,
                CarColor = "Grey",
                TotalSeats = 5,
            };


            var modelBinder = new ModelBindingContext()
            {
                ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(
                                  () => model, model.GetType()),
                ValueProvider = new NameValueCollectionValueProvider(
                                    new NameValueCollection(), CultureInfo.InvariantCulture)
            };

            //Act
            var binder = new DefaultModelBinder().BindModel(
                 new ControllerContext(), modelBinder);
            controller.ModelState.Clear();
            controller.ModelState.Merge(modelBinder.ModelState);
            var actual = (RedirectToRouteResult)controller.Event(model);

            var expectedMethod = "EventDisplay";
            var ExpectedControler = "Home";

            //Assert
            Assert.AreEqual(actual.RouteValues["action"], expectedMethod);
            Assert.AreEqual(actual.RouteValues["controller"], ExpectedControler);
        }

        [TestMethod]
        public void Test_Event_UserLoggedIn_ReturnView()
        {
            //Arrange 
            var controller = MockLoggedInUser("SomeUser");
            var expected = "";

            //Act
            var actual = ((ViewResult)controller.Event()).ViewName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Event_UserNotLoggedIn_ReturnView()
        {
            //Arrange 
            var controller = MockLoggedInUser("");
            var expected = "System.Web.Mvc.RedirectToRouteResult";

            //Act
            var actual = ((ActionResult)controller.Event());

            //Assert
            Assert.AreEqual(expected, actual.ToString());
        }


        /// <summary>
        /// Mocks logged in user
        /// </summary>
        HomeController MockLoggedInUser(string userName)
        {

            var mock = new Mock<ControllerContext>();
            mock.SetupGet(p => p.HttpContext.User.Identity.Name).Returns(userName);
            mock.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);

            var controller = new HomeController();
            controller.ControllerContext = mock.Object;

            return controller;
        }

    }
}
