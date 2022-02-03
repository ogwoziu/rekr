
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MillRekrutacja.API.Controllers;
using MillRekrutacja.Core.Models;
using MillRekrutacja.Core.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MillRekrutacja.API.Controllers.Tests
{
    [TestClass()]
    public class FakeControllerTests
    {
        [TestMethod()]
        public async Task GetById_Fake_Exists_Test()
        {
            //ARRANGE
            string fakeId = "test";
            Mock<ILogger<FakeModel>> loggerMock = new Mock<ILogger<FakeModel>>();
            Mock<IFakeService> serviceMock = new Mock<IFakeService>();

            serviceMock.Setup(s => s.GetFakeModelById(It.IsAny<string>()))
                .Returns(Task.FromResult(new FakeModel() { Id = fakeId, UniqueValue = "Test u", Value = "Test" }));

            //ACT
            var controller = new FakeController(loggerMock.Object, serviceMock.Object);
            IActionResult result = await controller.GetById(fakeId);

            //ASSERT
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            var okResult = result as OkObjectResult;
            var actualResult = okResult.Value as FakeModel;
            Assert.AreEqual(fakeId, actualResult.Id);
            Assert.IsNotNull(actualResult.UniqueValue, $"{nameof(actualResult.UniqueValue)} is null");
            Assert.IsNotNull(actualResult.Value, $"{nameof(actualResult.Value)} is null");
        }

        [TestMethod()]
        public async Task GetById_Null_Id_Test()
        {
            //ARRANGE
            Mock<ILogger<FakeModel>> loggerMock = new Mock<ILogger<FakeModel>>();
            Mock<IFakeService> serviceMock = new Mock<IFakeService>();

            serviceMock.Setup(s => s.GetFakeModelById(It.Is<string>(s => s == null)))
                .Throws(new ArgumentNullException());

            //ACT
            var controller = new FakeController(loggerMock.Object, serviceMock.Object);
            IActionResult result = await controller.GetById(null);

            //ASSERT
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
    }
}