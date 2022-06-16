using Microsoft.AspNetCore.Mvc;
using PizzaDeliveryApi.Models;
using PizzaDeliveryApi.Services;

namespace PizzaDeliveryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        public CustomerController()
        {
        }

        /// <summary>
        /// Return all pizza instanses
        /// </summary>
        /// <returns></returns>
        // GET all action
        [HttpGet]
        public ActionResult<List<Customer>> GetAll() =>
            CustomerService.GetAll();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            var customer = CustomerService.Get(id);

            if (customer == null)
                return NotFound();

            return customer;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            CustomerService.Add(customer);
            return CreatedAtAction(nameof(Create), new { id = customer.Id }, customer);
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Customer customer)
        {
            if (id != customer.Id)
                return BadRequest();

            var existingCustomer = CustomerService.Get(id);
            if (existingCustomer is null)
                return NotFound();

            CustomerService.Update(customer);

            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = CustomerService.Get(id);

            if (customer is null)
                return NotFound();

            CustomerService.Delete(id);

            return NoContent();
        }

    }
}
