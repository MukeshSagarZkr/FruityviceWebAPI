using FruityviceServices.Contract;
using FruityviceServices.Implementation;
using FruityviceWebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using Xunit;

namespace Fruityvice.Tests
{

    public class FruityViceControllerTest
    {
        public readonly FruityViceController _controller;
        public readonly IFruityViceService _service;
        public readonly HttpClient _httpClient;
        public FruityViceControllerTest()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://www.fruityvice.com");
            _service = new FruityViceService(_httpClient);
            _controller = new FruityViceController(_service);
        }

        [Fact]
        public void GetAllFruitTestCase()
        {

            var result = _controller.GetAll();
            Assert.IsInstanceOfType<OkResult>(result as OkObjectResult);
        }
    }
}
