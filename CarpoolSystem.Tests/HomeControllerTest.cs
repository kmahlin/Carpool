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
        //Will break because database isn't mocked
        public void Test_Event_ModelState_valid()
        {



            //Arrange 
            var accountController = new AccountController();



            var loginModel = new LogInModel()
            {
                UserName = "admin",
                Password = "123456",
            };
            accountController.LogIn(loginModel);

            var controller = new HomeController();
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

            ViewResult result = (ViewResult)controller.Event(model);

            //Assert
            Assert.IsTrue(!result.ViewData.ModelState.IsValid);

        }

        [TestMethod]
        public void Test_Event_ReturnView()
        {
            //Arrange 
            var controller = new HomeController();
            var expected = "";

            //Act
            var actual = ((ViewResult)controller.Event()).ViewName;

            //Assert
            Assert.AreEqual(expected, actual);
        }



    }
}
