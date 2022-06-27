using AutoMapper;
using PizzaDeliveryApi.Data;
using PizzaDeliveryApi.Data.DTOModels;
using PizzaDeliveryApi.Data.Interfaces;
using PizzaDeliveryApi.Data.Models;
using PizzaDeliveryApi.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PizzaDeliveryApi.Services
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _orders;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public OrderService(IOrderRepository orders, DataContext context, IMapper mapper)
        {
            _orders = orders;    
            _context = context;
            _mapper = mapper;
        }

        public async Task<Order> MakeOrderAsync(OrderDTO orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);   
       
            await _orders.CreateOrderAsync(order);
            await _context.SaveChangesAsync();

            return order;   
        }

        public async Task DeleteOrderByIdAsync(int id)
        {
            var existingOrder = await _orders.GetOrderByIdAsync(id);

            if ((existingOrder != null) && (existingOrder.Status.Name == "delivered"))
            {
                await _orders.DeleteOrderByIdAsync(existingOrder);
            }      
            else
            {
                throw new Exception("Order is not delivered yet");
            }
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _orders.GetAllOrdersAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _orders.GetOrderByIdAsync(id); 
        }

        public async Task<Order> EditOrderByIdAsync(int id, OrderDTO orderDto)
        {
            var order = await _orders.EditOrderByIdAsync(id, _mapper.Map<Order>(orderDto));
            await _context.SaveChangesAsync();

            return order;
        }

    }
}

