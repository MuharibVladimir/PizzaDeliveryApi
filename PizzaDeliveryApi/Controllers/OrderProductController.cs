using Microsoft.AspNetCore.Mvc;
using PizzaDeliveryApi.Data.Interfaces;
using PizzaDeliveryApi.Data.Models;
using PizzaDeliveryApi.Services;

namespace PizzaDeliveryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderProductController : ControllerBase
    {
        private readonly IOrderProductRepository _orderProducts;

        public OrderProductController(IOrderProductRepository orderProducts)
        {
            _orderProducts = orderProducts; 
        }

        /// <summary>
        /// Return all customer instanses
        /// </summary>
        /// <returns></returns>
        // GET all action
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAll()
        {
            return Ok(await _orderProducts.GetAllOrderProductsAsync());
        }


        // GET by Id action
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            return Ok(await _orderProducts.GetOrderProductByIdAsync(id));
        }

        // POST action
        [HttpPost]
        public async Task<IActionResult> Create(OrderProduct orderProduct)
        {
            return Ok(await _orderProducts.CreateOrderProductAsync(orderProduct));
        }

        // PUT action
        [HttpPut]
        public async Task<IActionResult> Edit(int id, OrderProduct orderProduct)
        {
            return Ok(await _orderProducts.EditOrderProductByIdAsync(id, orderProduct));

        }

        // DELETE action
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderProducts.DeleteOrderProductByIdAsync(id);
            return NoContent();
        }

    }
}
