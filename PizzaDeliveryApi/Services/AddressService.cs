using AutoMapper;
using PizzaDeliveryApi.Data;
using PizzaDeliveryApi.Data.DtoModels;
using PizzaDeliveryApi.Data.DTOModels;
using PizzaDeliveryApi.Data.Interfaces;
using PizzaDeliveryApi.Data.Models;
using PizzaDeliveryApi.Services.Interfaces;

namespace PizzaDeliveryApi.Services
{
      public class AddressService: IAddressService
    {
        private readonly IAddressRepository _addresses;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public AddressService(IAddressRepository addresses, IMapper mapper, DataContext context)
        {
            _addresses = addresses;
            _mapper = mapper;   
            _context = context; 
        }

        public async Task DeleteAddressByIdAsync(int id)
        {
            var existingAddress = await _addresses.GetAddressByIdAsync(id);

            if (existingAddress != null)
            {
                await _addresses.DeleteAddressByIdAsync(existingAddress);
            }   
        }

        public async Task<List<Address>> GetAllAddressesAsync()
        {
            return await _addresses.GetAllAddressesAsync();
        }

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            return await _addresses.GetAddressByIdAsync(id);
        }

        public async Task<Address> CreateAddressAsync(AddressDTO addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);

            await _addresses.CreateAddressAsync(address);
            await _context.SaveChangesAsync();

            return address;
        }

        public async Task<Address> EditAddressByIdAsync(int id, AddressDTO addressDto)
        {
            var address = await _addresses.EditAddressByIdAsync(id, _mapper.Map<Address>(addressDto));
            await _context.SaveChangesAsync();

            return address;
        }
    }
}
