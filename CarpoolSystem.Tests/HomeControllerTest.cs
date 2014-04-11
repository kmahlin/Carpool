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
            //Act
            var actual = (RedirectToRouteResult)controller.Event();

            var expectedMethod = "Login";
            var ExpectedControler = "Account";

            //Assert
            Assert.AreEqual(actual.RouteValues["action"], expectedMethod);
            Assert.AreEqual(actual.RouteValues["controller"], ExpectedControler);
        }
        
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

            var repositoryMock = new Mock<CarpoolSystem.Services.DatabaseManager.IRepository<MainDbEntities>>();
            repositoryMock.Object.createEvent(model.Title, model.StartingAddress, model.StartingCity,
                        model.StartingState, model.DestAddress, model.DestCity,
                        model.DestState, model.StartingTime, model.EndingTime,
                        model.EventInfo, model.Days);

            repositoryMock.Object.newCar(model.CarMake, model.CarModel, model.CarColor,
                        model.CarYear, model.TotalSeats);

            repositoryMock.Object.newDriver(controller.User.Identity.Name);



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
        public void Test_EventDisplay_ReturnView()
        {
            //Arrange 
            var controller = MockLoggedInUser("SomeUser");

            var expected = new EventDisplayModel()
            {
                Title = null,
                StartingAddress = null,
                StartingCity = null,
                StartingState = null,
                EndingAddress = null,
                DestCity = null,
                DestState = null,
                StartingTime = null,
                EndingTime = null,
                EventInfo = null,
                Days = null,
                CarMake = null,
                CarModel = null,
                CarYear = 0,
                CarColor = null,
                TotalSeats = 0,
            };

            //Act
            var actual = ((ViewResult)controller.EventDisplay()).ViewData.Model;

            //Assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void Test_MainPage_UserLoggedIn_ReturnView()
        {
            //Arrange 
            var controller = MockLoggedInUser("SomeUser");
            var expected = "";

            //Act
            var actual = ((ViewResult)controller.MainPage()).ViewName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_MainPage_UserNotLoggedIn_ReturnView()
        {
            //Arrange 
            var controller = MockLoggedInUser("");

            //Act
            var actual = (RedirectToRouteResult)controller.MainPage();

            var expectedMethod = "Login";
            var ExpectedControler = "Account";

            //Assert
            Assert.AreEqual(actual.RouteValues["action"], expectedMethod);
            Assert.AreEqual(actual.RouteValues["controller"], ExpectedControler);
        }

        [TestMethod]
        public void Test_About_ReturnView()
        {
            //Arrange 
            var controller = new HomeController();
            var expected = "";

            //Act
            var actual = ((ViewResult)controller.About()).ViewName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Search_UserLoggedIn_ReturnView()
        {
            //Arrange 
            var controller = MockLoggedInUser("SomeUser");
            var expected = "";

            //Act
            var actual = ((ViewResult)controller.Search()).ViewName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Search_UserNotLoggedIn_ReturnView()
        {
            //Arrange 
            var controller = MockLoggedInUser("");
            //Act
            var actual = (RedirectToRouteResult)controller.Search();

            var expectedMethod = "Login";
            var ExpectedControler = "Account";

            //Assert
            Assert.AreEqual(actual.RouteValues["action"], expectedMethod);
            Assert.AreEqual(actual.RouteValues["controller"], ExpectedControler);
        }

        [TestMethod]
        public void Test_SearchResults_ByState_ReturnPartialView()
        {
            //Arrange
            var controller = new HomeController();
            var model = new SearchModel
            {
                radioButton = true,
                StartingState = "NE",
                UserName = null,
            };

            //Act
            var actual = (PartialViewResult)controller.SearchResults(model);

            var expected = "_SearchEvent";

            //Assert
            Assert.AreEqual(actual.ViewName,expected);
        }

        [TestMethod]
        public void Test_SearchResults_ByUser_ReturnPartialView()
        {
            //Arrange
            var controller = new HomeController();
            var model = new SearchModel
            {
                radioButton = false,
                StartingState = null,
                UserName = "admin",
            };

            //Act
            var actual = (PartialViewResult)controller.SearchResults(model);

            var expected = "_SearchUser";

            //Assert
            Assert.AreEqual(actual.ViewName, expected);
        }

        [TestMethod]
        public void Test_SearchResults_Empty_ReturnView()
        {
            //Arrange
            var controller = new HomeController();
            var model = new SearchModel
            {
                radioButton = false,
                StartingState = null,
                UserName = null,
            };

            //Act
            var actual = ((ViewResult)controller.SearchResults(model)).ViewName;

            var expected = "";

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Test_SuccessfulReg_UserLoggedIn_ReturnView()
        {
            //Arrange 
            var controller = MockLoggedInUser("SomeUser");
            var expected = "";

            //Act
            var actual = ((ViewResult)controller.SuccessfulReg()).ViewName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_SuccessfulReg_UserNotLoggedIn_ReturnView()
        {
            //Arrange 
            var controller = MockLoggedInUser("");
            //Act
            var actual = (RedirectToRouteResult)controller.SuccessfulReg();

            var expectedMethod = "Login";
            var ExpectedControler = "Account";

            //Assert
            Assert.AreEqual(actual.RouteValues["action"], expectedMethod);
            Assert.AreEqual(actual.RouteValues["controller"], ExpectedControler);
        }

        #region Mocks

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
        #endregion
    }
}
