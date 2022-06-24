using PizzaDeliveryApi.Data.Models;

namespace PizzaDeliveryApi.Data.Interfaces
{
    public interface IAddressRepository
    {
        Task<List<Address>> GetAllAddressesAsync();
        Task<Address> GetAddressByIdAsync(int id);
        Task<Address> CreateAddressAsync(Address address);

        Task<Address> EditAddressByIdAsync(int id, Address address);
        Task DeleteAddressByIdAsync(int id);
    }
}
