using Microsoft.AspNetCore.Mvc;
using Moq;
using PizzaDeliveryApi.Controllers;
using PizzaDeliveryApi.Data;
using PizzaDeliveryApi.Data.Interfaces;
using PizzaDeliveryApi.Data.Models;
using PizzaDeliveryApi.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PizzaDeliveryApiTests
{
    public class OrderControllerTests
    {
        private readonly Mock<IOrderService> _orderService;
        private readonly OrderController _controller;

        public OrderControllerTests()
        {
            _orderService = new Mock<IOrderService>();
            _controller = new OrderController(_orderService.Object);
        }

    }
}