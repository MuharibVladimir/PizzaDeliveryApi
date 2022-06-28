using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApi.Data.Interfaces;
using PizzaDeliveryApi.Data.Models;

namespace PizzaDeliveryApi.Data.Repositories
{
    public class AddressRepository: IAddressRepository  
    {
        private readonly ILogger<AddressRepository> _logger;
        private readonly DataContext _context;

        public AddressRepository(DataContext context, ILogger<AddressRepository> logger)
        {
            _context = context;
            _logger = logger;   
        }

        public async Task<Address> CreateAddressAsync(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();

            return address;
        }

        public async Task<List<Address>> GetAllAddressesAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(address => address.Id == id);

            if (address == null)
            {
                _logger.LogError($"The address with id = {id} is not found");
            }

            return address;
        }

        public async Task<Address> EditAddressByIdAsync(int id, Address address)
        {
            _context.Entry(address).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return address;
        }

        public async Task DeleteAddressByIdAsync(Address address)
        { 
            {
                _context.Addresses.Remove(address);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"The address was successfully deleted");
            }
        }
    }
}
