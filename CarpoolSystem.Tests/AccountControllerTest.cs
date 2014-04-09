﻿using CarpoolSystem.Controllers;
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
        public void Test_Login_ReturnView()
        {
            //Arrange 
            var controller = new AccountController();
            var expected = "";

            //Act
            var actual = ((ViewResult)controller.Login()).ViewName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Registration_ReturnView()
        {
            //Arrange 
            var controller = new AccountController();
            var expected = "";

            //Act
            var actual = ((ViewResult)controller.Registration()).ViewName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Profile_ReturnView()
        {
            //Arrange 
            var controller = new AccountController();
            var expected = "";

            //Act
            var actual = ((ViewResult)controller.Profile()).ViewName;

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Test_PasswordChangeOk_ReturnView()
        {
            //Arrange 
            var controller = new AccountController();
            var expected = "";

            //Act
            var actual = ((ViewResult)controller.PasswordChangeOk()).ViewName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PasswordRetrieval_ReturnView()
        {
            //Arrange 
            var controller = new AccountController();
            var expected = "";

            //Act
            var actual = ((ViewResult)controller.PasswordRetrieval()).ViewName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_ChangePassword_ReturnView()
        {
            //Arrange 
            var controller = new AccountController();
            var expected = "";

            //Act
            var actual = ((ViewResult)controller.ChangePassword()).ViewName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_ChangePassword_Mismatch_Invalid_Post()
        {
            //Arrange 
            var controller = new AccountController();
            var model = new ChangePasswordModel()
            {
                OldPassword = "123457",
                NewPassword = "123457",
                ConfirmPassword = "12345",
            };
            var  expected = "Password doesn't match";
     

            //Act
            controller.ModelState.Clear();
            var actual = ((ViewResult)controller.ChangePassword(model)).ViewName;

            //Assert
            Assert.AreEqual(expected, actual);
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
