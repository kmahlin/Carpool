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
        public void Test_LogIn_ModelState_Invalid()
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

        [TestMethod]
        public void Test_LogIn_ModelState_Valid()
        {
            //Arrange
            var controller = MockLoggedInUser("SomeUser");
            controller.ViewData.ModelState.Clear();

            var model = new LogInModel()
            {
                UserName = "someUser",
                Password = "123456",
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
            var actual = (RedirectToRouteResult)controller.LogIn(model);

            var expectedMethod = "MainPage";
            var ExpectedControler = "Home";

            //Assert
            Assert.AreEqual(actual.RouteValues["action"], expectedMethod);
            Assert.AreEqual(actual.RouteValues["controller"], ExpectedControler);

        }

        [TestMethod]
        public void Test_LogIn_ModelState_Valid_InvalidUser()
        {
            //Arrange
            var controller = MockLoggedInUser("");
            controller.ViewData.ModelState.Clear();

            var model = new LogInModel()
            {
                UserName = "a",
                Password = "123456",
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
            ViewResult result = (ViewResult)controller.LogIn(model);

            //Assert
            Assert.IsTrue(!result.ViewData.ModelState.IsValid);
        }

        [TestMethod]
        public void Test_LogOut_ReturnView()
        {
            //Arrange 
            var controller = MockLoggedInUser("SomeUser");
            //Act
            
            var actual = (RedirectToRouteResult)controller.LogOut();

            var expectedMethod = "Login";
            var ExpectedControler = "Account";

            //Assert
            Assert.AreEqual(actual.RouteValues["action"], expectedMethod);
            Assert.AreEqual(actual.RouteValues["controller"], ExpectedControler);

        }

        [TestMethod]
        public void Test_Registration_ModelState_Invalid()
        {
            //Arrange 
            var controller = new AccountController();
            controller.ViewData.ModelState.Clear();

            var model = new AccountModel();

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

            ViewResult result = (ViewResult)controller.Registration(model);

            //Assert
            Assert.IsTrue(!result.ViewData.ModelState.IsValid);

        }

        [TestMethod]
        public void Test_Registration_ModelState_valid_UserNameExists()
        {

            //Arrange
            var controller = MockLoggedInUser("SomeUser");
            controller.ViewData.ModelState.Clear();

            var model = new AccountModel()
            {
                CreateDate = new DateTime(2010, 1, 18),
                Email = "Hi@gmail.com",
                FirstName = "Kevin",
                LastName = "Mahlin",
                Password = "123456",
                Phone = 123456789,
                UserName = "admin",
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
            ViewResult result = (ViewResult)controller.Registration(model);

            //Assert
            Assert.IsTrue(!result.ViewData.ModelState.IsValid);
        }

        [TestMethod]
        public void Test_Registration_ModelState_valid_UserDoesNotExist()
        {

            //Arrange
            var controller = MockLoggedInUser("");
            controller.ViewData.ModelState.Clear();

            var model = new AccountModel()
            {
                CreateDate = new DateTime(2010, 1, 18),
                Email = "361CarpoolSystem@gmail.com",
                FirstName = "Kevin",
                LastName = "Mahlin",
                Password = "123456",
                Phone = 123456789,
                UserName = "admin",
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
            var actual = (RedirectToRouteResult)controller.Registration(model);

            var expectedMethod = "SuccessfulReg";
            var ExpectedControler = "Home";

            //Assert
            Assert.AreEqual(actual.RouteValues["action"], expectedMethod);
            Assert.AreEqual(actual.RouteValues["controller"], ExpectedControler);
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
        public void Test_Profile_UserLoggedIn_ReturnView()
        {
            //Arrange 
            var controller = MockLoggedInUser("SomeUser");
            var expected = "";

            //Act
            var actual = ((ViewResult)controller.Profile()).ViewName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Profile_UserNotLoggedIn_ReturnView()
        {
            //Arrange 
            var controller = MockLoggedInUser("");
            //Act
            var actual = (RedirectToRouteResult)controller.Profile();

            var expectedMethod = "Login";
            var ExpectedControler = "Account";

            //Assert
            Assert.AreEqual(actual.RouteValues["action"], expectedMethod);
            Assert.AreEqual(actual.RouteValues["controller"], ExpectedControler);
        }

        [TestMethod]
        public void Test_ChangePassword_UserLoggedIn_ReturnView()
        {
            //Arrange 
            var controller = MockLoggedInUser("SomeUser");
            var expected = "";

            //Act
            var actual = ((ViewResult)controller.ChangePassword()).ViewName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_ChangePassword_UserNotLoggedIn_ReturnView()
        {
            //Arrange 
            var controller = MockLoggedInUser("");
            //Act
            var actual = (RedirectToRouteResult)controller.ChangePassword();

            var expectedMethod = "Login";
            var ExpectedControler = "Account";

            //Assert
            Assert.AreEqual(actual.RouteValues["action"], expectedMethod);
            Assert.AreEqual(actual.RouteValues["controller"], ExpectedControler);
        }

        [TestMethod]
        public void Test_ChangePassword_ModelState_Invalid_ReturnView()
        {

            //Arrange 
            var controller = new AccountController();
            controller.ViewData.ModelState.Clear();

            var model = new ChangePasswordModel();

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

            ViewResult result = (ViewResult)controller.ChangePassword(model);

            //Assert
            Assert.IsTrue(!result.ViewData.ModelState.IsValid);

        }

       
        [TestMethod]
        public void Test_ChangePassword_ModelState_Valid_PasswordMismatch_Post()
        {
            //Arrange 
            var controller = new AccountController();
            var model = new ChangePasswordModel()
            {
                OldPassword = "123457",
                NewPassword = "123457",
                ConfirmPassword = "12345",
            };
            var expected = "Password doesn't match";


            //Act
            controller.ModelState.Clear();
            var actual = ((ViewResult)controller.ChangePassword(model)).ViewName;

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
        public void Test_PasswordRetrieval_ModelState_Invalid_ReturnView()
        {
            //Arrange 
            var controller = new AccountController();
            controller.ViewData.ModelState.Clear();

            var model = new PasswordRetrievalModel();

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

            ViewResult result = (ViewResult)controller.PasswordRetrieval(model);

            //Assert
            Assert.IsTrue(!result.ViewData.ModelState.IsValid);
        }

        [TestMethod]
        public void Test_PasswordRetrieval_ModelState_valid_ReturnView()
        {
            //Arrange 
            var controller = new AccountController();
            controller.ViewData.ModelState.Clear();

            var model = new PasswordRetrievalModel()
            {
                ConfirmEmail = "361CarpoolSystem@gmail.com",
                Email  = "361CarpoolSystem@gmail.com",
                UserName = "admin",
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

            var actual = (RedirectToRouteResult)controller.PasswordRetrieval(model);

            var expectedMethod = "PasswordChangeOk";
            var ExpectedControler = "Account";

            //Assert
            Assert.AreEqual(actual.RouteValues["action"], expectedMethod);
            Assert.AreEqual(actual.RouteValues["controller"], ExpectedControler);
        }

        #region Mocks
        AccountController MockLoggedInUser(string userName)
        {
            var mock = new Mock<ControllerContext>();
            mock.SetupGet(p => p.HttpContext.User.Identity.Name).Returns(userName);
            mock.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);


            var controller = new AccountController();
            controller.ControllerContext = mock.Object;

            return controller;
        }


        #endregion

    }
}
