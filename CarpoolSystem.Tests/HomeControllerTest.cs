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
