using AutoMapper;
using PizzaDeliveryApi.Data.DTOModels;
using PizzaDeliveryApi.Data.Models;

namespace PizzaDeliveryApi.Profiles
{
    public class OrderProfile: Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDTO>().ReverseMap();
        }
    }
}
