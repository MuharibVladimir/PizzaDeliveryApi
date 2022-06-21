using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApi.Data;
using PizzaDeliveryApi.Interfaces;
using PizzaDeliveryApi.Models;
using PizzaDeliveryApi.Services;

namespace PizzaDeliveryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ICustomerRepository _customers;

        public CustomerController(ICustomerRepository customers)
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
        public  async Task<IActionResult> Create([FromBody] Customer customer)
        {
            return Ok(await _customers.CreateCustomerAsync(customer));
        }

        // PUT action
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] Customer customer)
        {
            if (id != customer.Id)
                return BadRequest("What's wrong with it?");


            var existingCustomer = await _context.Customers.FindAsync(id);
            if (existingCustomer is null)
                return NotFound();

            _context.Customers.Update(customer);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer is null)
                return NotFound();

            _context.Customers.Remove(customer);
            _context.SaveChanges(); 

            return NoContent();
        }

    }
}
