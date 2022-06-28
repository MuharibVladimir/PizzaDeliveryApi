using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApi.Data.Interfaces;
using PizzaDeliveryApi.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace PizzaDeliveryApi.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<CustomerRepository> _logger;   

        public CustomerRepository(DataContext context, ILogger<CustomerRepository> logger)
        {
           _context = context;
            _logger = logger;   
        } 

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            _logger.LogInformation("The new customer is successfully added");

            return customer;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(customer => customer.Id == id);

            return customer;
        }

        public async Task<Customer> EditCustomerByIdAsync(int id, Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task DeleteCustomerByIdAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
