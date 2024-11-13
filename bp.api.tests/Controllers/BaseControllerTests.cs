using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using bp.api.Controllers;
using bp.api.tests.Models;
using bp.domain.Interfaces;
using bp.domain.Models;
using Xunit;

namespace bp.tests.Controllers
{
    public class BaseControllerTests
    {
        private readonly Mock<ILogger<BaseController<TestEntity>>> _loggerMock;
        private readonly Mock<IGet<TestEntity>> _getServiceMock;
        private readonly Mock<IUpdate<TestEntity>> _updateServiceMock;
        private readonly Mock<ICreate<TestEntity>> _createServiceMock;
        private readonly BaseController<TestEntity> _controller;

        public BaseControllerTests()
        {
            _loggerMock = new Mock<ILogger<BaseController<TestEntity>>>();
            _getServiceMock = new Mock<IGet<TestEntity>>();
            _updateServiceMock = new Mock<IUpdate<TestEntity>>();
            _createServiceMock = new Mock<ICreate<TestEntity>>();

            _controller = new BaseController<TestEntity>(_loggerMock.Object, _createServiceMock.Object, _getServiceMock.Object, _updateServiceMock.Object);
        }

        // Test for Get(int id)
        [Fact]
        public async Task Get_ReturnsOkResult_WhenEntityExists()
        {
            int testId = 1;
            var testEntity = new TestEntity { Id = testId };
            _getServiceMock.Setup(service => service.ByIdAsync(testId)).ReturnsAsync(testEntity);

            var result = await _controller.Get(testId);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(testEntity, okResult.Value);
        }

        [Fact]
        public async Task Get_ReturnsNotFoundResult_WhenEntityDoesNotExist()
        {
            int testId = 1;
            TestEntity? _ = null;
            _getServiceMock.Setup(service => service.ByIdAsync(testId)).ReturnsAsync(_);

            var result = await _controller.Get(testId);

            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal(StatusCodes.Status404NotFound, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task Get_ReturnsInternalServerError_OnException()
        {
            int testId = 1;
            _getServiceMock.Setup(service => service.ByIdAsync(testId)).ThrowsAsync(new Exception("Error"));

            var result = await _controller.Get(testId);

            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }

        // Test for GetAll()
        [Fact]
        public async Task GetAll_ReturnsOkResult_WithEntities()
        {
            var testEntities = new List<TestEntity> { new() { Id = 1 }, new() { Id = 2 } };
            _getServiceMock.Setup(service => service.AllAsync()).ReturnsAsync(testEntities);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(testEntities, okResult.Value);
        }

        [Fact]
        public async Task GetAll_ReturnsInternalServerError_OnException()
        {
            _getServiceMock.Setup(service => service.AllAsync()).ThrowsAsync(new Exception("Error"));

            var result = await _controller.GetAll();

            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }

        // Test for Create(T entity)
        [Fact]
        public async Task Create_ReturnsOkResult_WhenCreationIsSuccessful()
        {
            var testEntity = new TestEntity { Id = 1 };
            _createServiceMock.Setup(service => service.NewAsync(testEntity)).Returns(Task.CompletedTask);

            var result = await _controller.Create(testEntity);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(testEntity, okResult.Value);
        }

        [Fact]
        public async Task Create_ReturnsInternalServerError_OnException()
        {
            var testEntity = new TestEntity { Id = 1 };
            _createServiceMock.Setup(service => service.NewAsync(testEntity)).ThrowsAsync(new Exception("Error"));

            var result = await _controller.Create(testEntity);

            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }

        // Test for Update(T entity)
        [Fact]
        public async Task Update_ReturnsOkResult_WhenUpdateIsSuccessful()
        {
            // Arrange
            var testEntity = new TestEntity { Id = 1 };
            _updateServiceMock.Setup(service => service.EntityAsync(testEntity)).Returns(Task.FromResult(testEntity));

            // Act
            var result = await _controller.Update(testEntity);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(testEntity, okResult.Value);
        }

        [Fact]
        public async Task Update_ReturnsInternalServerError_OnException()
        {
            var testEntity = new TestEntity { Id = 1 };
            _updateServiceMock.Setup(service => service.EntityAsync(testEntity)).ThrowsAsync(new Exception("Error"));

            var result = await _controller.Update(testEntity);

            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }
    }
}