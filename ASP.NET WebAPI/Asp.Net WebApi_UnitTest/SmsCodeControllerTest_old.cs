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
        [Fact]
        public void SendCode_Retun_OK()
        {
            // mock entities
            var smsCodesMock = new Mock<DbSet<SmsCode>>();
            smsCodesMock.AsQuerable<SmsCode>();

            var usertypeMock = new Mock<DbSet<UserType>>();
            usertypeMock.AsQuerable<UserType>();

            // mock DbContext
            var mockDB = new Mock<MyDBContext>();
            mockDB.SetupGet(x => x.SmsCodes).Returns(smsCodesMock.Object);
            mockDB.SetupGet(x => x.UserTypes).Returns(usertypeMock.Object);

            var mockHandler = new Mock<ITwilioHandler>();
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
            // mock entities
            var smsCodesMock = new Mock<DbSet<SmsCode>>();
            smsCodesMock.AsQuerable<SmsCode>();

            var usertypeMock = new Mock<DbSet<UserType>>();
            usertypeMock.AsQuerable<UserType>();

            // mock DbContext
            var mockDB = new Mock<MyDBContext>();
            mockDB.SetupGet(x => x.SmsCodes).Returns(smsCodesMock.Object);
            mockDB.SetupGet(x => x.UserTypes).Returns(usertypeMock.Object);

            var mockHandler = new Mock<ITwilioHandler>();
            mockHandler.Setup(x => x.SendMessage(It.IsAny<string>(), It.IsAny<string>()));

            SmsCodeController smsCodeController = new SmsCodeController(mockDB.Object, mockHandler.Object);

            // Act
            SmsCodeModel smsCodeModel = null;

            var v = smsCodeController.Post(smsCodeModel);
            Assert.IsType<BadRequestObjectResult>(v);
        }

    }
}
