using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApi.Data;
using PizzaDeliveryApi.Data.Interfaces;
using PizzaDeliveryApi.Data.Models;
using PizzaDeliveryApi.Services;

namespace PizzaDeliveryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customers;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerRepository customers, ILogger<CustomerController> logger)
        {
            _customers = customers; 
        }

        /// <summary>
        /// Return all customer instanses
        /// </summary>
        /// <returns></returns>
        // GET all action
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAll()
        {
            return Ok(await _customers.GetAllCustomersAsync());
        }
            

        // GET by Id action
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            return Ok(await _customers.GetCustomerByIdAsync(id));
        }

        // POST action
        [HttpPost]
        public  async Task<IActionResult> Create(Customer customer)
        {
            return Ok(await _customers.CreateCustomerAsync(customer));
        }

        // PUT action
        [HttpPut]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            return Ok(await _customers.EditCustomerByIdAsync(id,customer));

        }

        // DELETE action
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customers.DeleteCustomerByIdAsync(id);
            return NoContent();
        }

    }
}
