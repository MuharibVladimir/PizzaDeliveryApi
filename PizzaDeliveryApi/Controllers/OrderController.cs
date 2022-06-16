using Microsoft.AspNetCore.Mvc;
using PizzaDeliveryApi.Models;
using PizzaDeliveryApi.Services;

namespace PizzaDeliveryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        public OrderController()
        {
        }

        [HttpGet]
        public ActionResult<List<Order>> GetAll() =>
           OrderService.GetAll();

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
