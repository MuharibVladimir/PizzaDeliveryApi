using AutoMapper;
using PizzaDeliveryApi.Data;
using PizzaDeliveryApi.Data.DTOModels;
using PizzaDeliveryApi.Data.Interfaces;
using PizzaDeliveryApi.Data.Models;
using PizzaDeliveryApi.Services.Interfaces;

namespace PizzaDeliveryApi.Services
{
     public class OrderProductService: IOrderProductService
    {
        private readonly IOrderProductRepository _orderProducts;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public OrderProductService(IOrderProductRepository orderProducts, IMapper mapper, DataContext context)
        {
            _orderProducts = orderProducts; 
            _mapper = mapper;   
            _context = context; 
        }
    }
}
