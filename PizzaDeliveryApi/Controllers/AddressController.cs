using Microsoft.AspNetCore.Mvc;
using PizzaDeliveryApi.Data.DtoModels;
using PizzaDeliveryApi.Data.Interfaces;
using PizzaDeliveryApi.Data.Models;
using PizzaDeliveryApi.Services.Interfaces;

namespace PizzaDeliveryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addresses;
        private readonly IAddressService _services;
        public AddressController(IAddressRepository addresses, IAddressService services)
        {
            _addresses = addresses;
            _services = services;   
        }
        /// <summary>
        /// Return all customer instanses
        /// </summary>
        /// <returns></returns>
        // GET all action
        [HttpGet]
        public async Task<ActionResult<List<Address>>> GetAll()
        {
            return Ok(await _services.GetAllAddressesAsync());
        }


        // GET by Id action
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> Get(int id)
        {
            return Ok(await _services.GetAddressByIdAsync(id));
        }

        // POST action
        [HttpPost]
        public async Task<IActionResult> Create(AddressDTO addressDto)
        {
            return Ok(await _services.CreateAddressAsync(addressDto));
        }

        // PUT action
        [HttpPut]
        public async Task<IActionResult> Edit(int id, AddressDTO addressDto)
        {
            return Ok(await _services.EditAddressByIdAsync(id, addressDto));

        }

        // DELETE action
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _services.DeleteAddressByIdAsync(id);
            return NoContent();
        }
    }
}
