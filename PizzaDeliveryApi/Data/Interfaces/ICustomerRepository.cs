using Microsoft.AspNetCore.Mvc;
using PizzaDeliveryApi.Data.Models;

namespace PizzaDeliveryApi.Data.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);  
        Task<Customer> CreateCustomerAsync(Customer customer); 

        Task<Customer> EditCustomerByIdAsync(int id, Customer customer);
        Task DeleteCustomerByIdAsync(int id);
    }
}
