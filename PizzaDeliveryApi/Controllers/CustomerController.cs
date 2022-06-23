using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApi.Data;
using PizzaDeliveryApi.Interfaces;
using PizzaDeliveryApi.Data.Models;
using PizzaDeliveryApi.Services;

namespace PizzaDeliveryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ICustomerRepository _customers;

        public CustomerController(ICustomerRepository customers, DataContext context)
        {
            _customers = customers;
            _context = context;
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
        [HttpPut]
        public /*async*/ /*Task<*/IActionResult/*>*/ Edit(Customer customer)
        {
            //if (id != customer.Id)
            //    return BadRequest("What's wrong with it?");

            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
            //var existingCustomer = await _context.Customers.FindAsync(customer.Id);
            //if (existingCustomer is null)
            //    return NotFound();

            //_context.Customers.Update(customer);
            

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
