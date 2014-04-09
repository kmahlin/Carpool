using CarpoolSystem.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;
using CarpoolSystem.Models;

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














    }
}
