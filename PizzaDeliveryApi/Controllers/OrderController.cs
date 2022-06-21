using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApi.Data;
using PizzaDeliveryApi.Models;
using PizzaDeliveryApi.Services;

namespace PizzaDeliveryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly DataContext _context;
        public OrderController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAll()
        {
            var orders = await _context.Orders.ToListAsync();
            return Ok(orders);
        }

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            var order = OrderService.Get(id);

            if (order == null)
                return NotFound();

            return order;
        }

       

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Order order)
        {
            if (id != order.Id)
                return BadRequest();

            var existingOrder = OrderService.Get(id);
            if (existingOrder is null)
                return NotFound();

            OrderService.Update(order);

            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = OrderService.Get(id);

            if (order is null)
                return NotFound();

            OrderService.Delete(id);

            return NoContent();
        }
    }
}
