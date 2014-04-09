using CarpoolSystem.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;
using CarpoolSystem.Models;
using Moq;
using System.Collections.Specialized;
using System.Globalization;

namespace CarpoolSystem.Tests
{

    [TestClass()]
    public class AccountControllerTest
    {
        AccountController CreateControllerAs(string userName)
        {

            var mock = new Mock<ControllerContext>();
            mock.SetupGet(p => p.HttpContext.User.Identity.Name).Returns(userName);
            mock.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);

            var controller = new AccountController();
            controller.ControllerContext = mock.Object;

            return controller;
        }

        [TestMethod]
        public void EditAction_Should_Return_EditView_When_ValidOwner()
        {

            // Arrange
            var controller = CreateControllerAs("SomeUser");

            // Act
            var result = controller.Profile() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(ProfileModel));
        }

        [TestMethod]
        public void Test_Login_ModelState_Invalid()
        {
            //Arrange 
            var controller = new AccountController();
            controller.ViewData.ModelState.Clear();

            var model = new LogInModel();

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

            ViewResult result = (ViewResult)controller.LogIn(model);

            //Assert
            Assert.IsTrue(!result.ViewData.ModelState.IsValid);
        }

    }
}
