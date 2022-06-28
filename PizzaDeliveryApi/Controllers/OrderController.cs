using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApi.Data;
using PizzaDeliveryApi.Data.Interfaces;
using PizzaDeliveryApi.Data.Models;
using PizzaDeliveryApi.Services;
using PizzaDeliveryApi.Services.Interfaces;
using PizzaDeliveryApi.Data.DTOModels;

namespace PizzaDeliveryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IOrderRepository _orders;
        private readonly IOrderService _services;

        public OrderController(IOrderRepository orders, DataContext context, IOrderService services)
        {
            _orders = orders;
            _context = context;
            _services = services;
        }

        /// <summary>
        /// Return all order instanses
        /// </summary>
        /// <returns></returns>
        // GET all action
        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAll()
        {
            return Ok(await _services.GetAllOrdersAsync());
        }

        /// <summary>
        /// Return certain order instanse by id
        /// </summary>
        /// <returns></returns>
        // GET by Id action
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            return Ok(await _services.GetOrderByIdAsync(id));
        }

        /// <summary>
        /// Create new order instanse
        /// </summary>
        /// <returns></returns>
        // POST action
        [HttpPost]
        public async Task<IActionResult> Create(OrderDTO order)
        {
            await _services.MakeOrderAsync(order);
            return Ok();
        }

        /// <summary>
        /// Edit certain order instanse by id
        /// </summary>
        /// <returns></returns>
        // PUT action
        [HttpPut]
        public async Task<IActionResult> Edit(int id, OrderDTO order)
        {
            return Ok(await _services.EditOrderByIdAsync(id, order));

        }

        /// <summary>
        /// Delete certain order instanse by id
        /// </summary>
        /// <returns></returns>
        // DELETE action
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _services.DeleteOrderByIdAsync(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrdersByStatusNameAsync(string status)
        {
            return Ok(await _services.GetOrdersByStatusNameAsync(status));
        }
    }
}
