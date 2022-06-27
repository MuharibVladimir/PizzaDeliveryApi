using AutoMapper;
using PizzaDeliveryApi.Data.DtoModels;
using PizzaDeliveryApi.Data.Models;

namespace PizzaDeliveryApi.Profiles
{
    public class OrderProductProfile: Profile
    {
        public OrderProductProfile()
        {
            CreateMap<OrderProduct, OrderProductDTO>().ReverseMap();
        }
    }
}
