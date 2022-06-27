using Microsoft.AspNetCore.Mvc;
using PizzaDeliveryApi.Data.DtoModels;
using PizzaDeliveryApi.Data.Interfaces;
using PizzaDeliveryApi.Data.Models;
using PizzaDeliveryApi.Services;
using PizzaDeliveryApi.Services.Interfaces;

namespace PizzaDeliveryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderProductController : ControllerBase
    {
        private readonly IOrderProductService _services;

        public OrderProductController(IOrderProductService services)
        {
            _services = services; 
        }

        /// <summary>
        /// Return all customer instanses
        /// </summary>
        /// <returns></returns>
        // GET all action
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAll()
        {
            return Ok(await _services.GetAllOrderProductsAsync());
        }


        // GET by Id action
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            return Ok(await _services.GetOrderProductByIdAsync(id));
        }

        // POST action
        [HttpPost]
        public async Task<IActionResult> Create(OrderProductDTO orderProductDto)
        {
            return Ok(await _services.CreateOrderProductAsync(orderProductDto));
        }

        // PUT action
        [HttpPut]
        public async Task<IActionResult> Edit(int id, OrderProductDTO orderProductDto)
        {
            return Ok(await _services.EditOrderProductByIdAsync(id, orderProductDto));

        }

        // DELETE action
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _services.DeleteOrderProductByIdAsync(id);
            return NoContent();
        }

    }
}
