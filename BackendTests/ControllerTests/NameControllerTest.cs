using backend.Contracts;
using backend.Controllers;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendTests.ControllerTests
{
    public class NameControllerTest
    {
        private readonly NameController _controller;
        private readonly INameService _service;
        public NameControllerTest()
        {
            _service = new NameService();
            _controller = new NameController(new NullLogger<NameController>(), _service);
        }

        [Test]
        public void Get_WhenCalled_ReturnsNameType()
        {
            // Act
            var nameResult = _controller.Get();
            // Assert
            Assert.IsInstanceOf<Name>(nameResult as Name);
        }
        [Test]
        public void Get_WhenCalled_ReturnsHello()
        {
            // Act
            var nameResult = _controller.Get() as Name;

            // Assert
            Assert.AreEqual("World", nameResult.name);
        }
    }
}
