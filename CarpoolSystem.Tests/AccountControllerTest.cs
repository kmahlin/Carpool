using CarpoolSystem.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;
using CarpoolSystem.Models;
using Moq;

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






    }
}
