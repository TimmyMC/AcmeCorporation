using AcmeCorporationMVC.Controllers;
using AcmeCorporationMVC.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Script.Serialization;
using static AcmeCorporationClassLibrary.BusinessLogic.SubmissionProcessor;

namespace AcmeCorporationMVC.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void SubmitSerial_OnlyTwoSubmissionsPerSerialAllowed()
        {
            // Arrange
            TestDBCleanup();
            HomeController controller = new HomeController();
            SubmissionModel submissionModel = new SubmissionModel
            {
                FirstName = "Test",
                LastName = "Test",
                EmailAddress = "Test@test.com",
                SerialNumber = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                IsOldEnough = true

            };

            // Act
            string result1 = new JavaScriptSerializer().Serialize(controller.SubmitSerial(submissionModel).Data);
            string result2 = new JavaScriptSerializer().Serialize(controller.SubmitSerial(submissionModel).Data);
            string result3 = new JavaScriptSerializer().Serialize(controller.SubmitSerial(submissionModel).Data);

            //Assert
            Assert.AreEqual("\"Submission Successful!\"", result1);
            Assert.AreEqual("\"Submission Successful!\"", result2);
            Assert.AreEqual("\"This Serial Number has already been redeemed twice.\"", result3);

            TestDBCleanup();
        }

        [TestMethod]
        public void SubmitSerial_OnlyValidSerialsAllowed()
        {
            // Arrange
            TestDBCleanup();
            HomeController controller = new HomeController();
            SubmissionModel submissionModel = new SubmissionModel
            {
                FirstName = "Test",
                LastName = "Test",
                EmailAddress = "Test@test.com",
                SerialNumber = Guid.Parse("11111111-1111-1111-1111-11111111111A"),
                IsOldEnough = true
            };

            // Act
            string result1 = new JavaScriptSerializer().Serialize(controller.SubmitSerial(submissionModel).Data);

            //Assert
            Assert.AreEqual("\"That is not a valid Serial Number.\"", result1);

            TestDBCleanup();
        }

        private void TestDBCleanup()
        {
            //Cleanup - Shouldn't be testing on the live server.
            DeleteSubmissionBySerial(Guid.Parse("11111111-1111-1111-1111-111111111111"));
        }
    }

}
