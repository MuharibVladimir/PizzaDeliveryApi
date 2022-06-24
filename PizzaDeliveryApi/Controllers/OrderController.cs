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
        /// Return all customer instanses
        /// </summary>
        /// <returns></returns>
        // GET all action
        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAll()
        {
            return Ok(await _orders.GetAllOrdersAsync());
        }


        // GET by Id action
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            return Ok(await _orders.GetOrderByIdAsync(id));
        }

        // POST action
        [HttpPost]
        public async Task<IActionResult> Create(OrderDTO order)
        {
            await _services.MakeOrder(order);
            return Ok();
        }

        // PUT action
        [HttpPut]
        public async Task<IActionResult> Edit(int id, [FromBody] Order customer)
        {
            return Ok(await _orders.EditOrderByIdAsync(id, customer));

        }

        // DELETE action
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _services.DeleteOrderByIdAsync(id);
            return NoContent();
        }
    }
}
