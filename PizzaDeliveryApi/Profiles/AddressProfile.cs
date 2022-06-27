using AutoMapper;
using PizzaDeliveryApi.Data.DtoModels;
using PizzaDeliveryApi.Data.Models;

namespace PizzaDeliveryApi.Profiles
{
    public class AddressProfile: Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDTO>().ReverseMap();
        }
    }
}
