using Moq;
using System;
using System.Web.Mvc;
using CarpoolSystem.Models;
using CarpoolSystem.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Collections.Specialized;
using  System.Globalization;

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
        public void Test_Home_Index()
        {

            var controller = new HomeController();
            var expected = "EventDisplay";
            var actual = ((ViewResult)controller.EventDisplay()).ViewName;
            Assert.AreEqual(expected, actual);
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
