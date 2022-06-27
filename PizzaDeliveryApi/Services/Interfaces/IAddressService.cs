using PizzaDeliveryApi.Data.DtoModels;
using PizzaDeliveryApi.Data.Models;

namespace PizzaDeliveryApi.Services.Interfaces
{
    public interface IAddressService
    {
        Task<Address> CreateAddressAsync(AddressDTO addressDto);
        Task<Address> EditAddressByIdAsync(int id, AddressDTO addressDto);
        Task<List<Address>> GetAllAddressesAsync();
        Task<Address> GetAddressByIdAsync(int id);
        Task DeleteAddressByIdAsync(int id);
    }
}
