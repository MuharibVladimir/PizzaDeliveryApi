using PizzaDeliveryApi.Data.Models;
using PizzaDeliveryApi.Services;
using Microsoft.AspNetCore.Mvc;
using PizzaDeliveryApi.Data.Interfaces;

namespace PizzaDeliveryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _products;

        public ProductController(IProductRepository products)
        {
            _products = products;
        }
        /// <summary>
        /// Return all customer instanses
        /// </summary>
        /// <returns></returns>
        // GET all action
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAll()
        {
            return Ok(await _products.GetAllProductsAsync());
        }


        // GET by Id action
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            return Ok(await _products.GetProductByIdAsync(id));
        }

        // POST action
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            return Ok(await _products.CreateProductAsync(product));
        }

        // PUT action
        [HttpPut]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            return Ok(await _products.EditProductByIdAsync(id, product));

        }

        // DELETE action
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _products.DeleteProductByIdAsync(id);
            return NoContent();
        }
    }
}
