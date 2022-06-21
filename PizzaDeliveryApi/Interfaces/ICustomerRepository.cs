using PizzaDeliveryApi.Models;

namespace PizzaDeliveryApi.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);  
        Task<Customer> CreateCustomerAsync(Customer customer);
        //Task<Customer> EditCustomerByIdAsync(int id, Customer customer);
        //Task<Customer> DeleteCustomerByIdAsync(int id);
    }
}
