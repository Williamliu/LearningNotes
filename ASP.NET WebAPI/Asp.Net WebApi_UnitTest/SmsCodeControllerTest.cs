using Barton.WebPortal.Controllers;
using Barton.WebPortal.Controllers.Entities;
using Barton.WebPortal.Controllers.TwilioHandler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Barton.UnitTest
{
    public class SmsCodeControllerTest
    {
        private MyDBContext TestDB { get; set; }
        public SmsCodeControllerTest()
        {
            DbContextOptionsBuilder<MyDBContext> optionBuilder = new DbContextOptionsBuilder<MyDBContext>();
            optionBuilder.UseInMemoryDatabase("MyTestDB");
            this.TestDB = new MyDBContext(optionBuilder.Options);
        }
        [Fact]
        public void SendCode_Retun_OK()
        {

            // Arrange
            var mockDB = new Mock<MyDBContext>();
            var mockHandler = new Mock<ITwilioHandler>();

            mockDB.SetupGet(x => x.SmsCodes).Returns(this.TestDB.SmsCodes);
            mockDB.SetupGet(x => x.UserTypes).Returns(this.TestDB.UserTypes);

            mockHandler.Setup(x => x.SendMessage(It.IsAny<string>(), It.IsAny<string>()));

            SmsCodeController smsCodeController = new SmsCodeController(mockDB.Object, mockHandler.Object);

            // Act
            SmsCodeModel smsCodeModel = new SmsCodeModel
            {
                phone = "any thing"
            };
            var v = smsCodeController.Post(smsCodeModel);
            Assert.IsType<OkResult>(v);
        }

        [Fact]
        public void SendCode_Return_BadRequest()
        {
            // Arrange
            var mockDB = new Mock<MyDBContext>();
            var mockHandler = new Mock<ITwilioHandler>();

            mockDB.SetupGet(x => x.SmsCodes).Returns(this.TestDB.SmsCodes);
            mockDB.SetupGet(x => x.UserTypes).Returns(this.TestDB.UserTypes);

            mockHandler.Setup(x => x.SendMessage(It.IsAny<string>(), It.IsAny<string>()));

            SmsCodeController smsCodeController = new SmsCodeController(mockDB.Object, mockHandler.Object);

            // Act
            SmsCodeModel smsCodeModel = null;

            var v = smsCodeController.Post(smsCodeModel);
            Assert.IsType<BadRequestObjectResult>(v);
        }

    }
}
