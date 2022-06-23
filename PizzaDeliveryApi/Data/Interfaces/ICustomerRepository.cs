using PizzaDeliveryApi.Data.Models;

namespace PizzaDeliveryApi.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);  
        Task<Customer> CreateCustomerAsync(Customer customer);
        //Task<Customer> EditCustomerByIdAsync(Customer customer);
        //Task DeleteCustomerByIdAsync(int id);
    }
}
