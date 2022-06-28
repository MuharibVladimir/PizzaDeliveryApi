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
        private readonly ILogger<IOrderService> _logger; 

        public OrderService(IOrderRepository orders, IMapper mapper, ILogger<IOrderService> _logger)
        {
            _orders = orders;    
            _mapper = mapper;
            _logger = _logger;  
        }

        public async Task<Order> MakeOrderAsync(OrderDTO orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);   
       
            await _orders.CreateOrderAsync(order);

            _logger.LogInformation("New order was successfully created");

            return order;   
        }

        public async Task DeleteOrderByIdAsync(int id)
        {
            var existingOrder = await _orders.GetOrderByIdAsync(id);

            if (existingOrder == null)
            {
                _logger.LogError($"There is no order with defined id = {id}");
            }
            else if ((existingOrder.Status.Name == "delivered") || (existingOrder.Status.Name == "cancelled"))
            {
                await _orders.DeleteOrderByIdAsync(existingOrder);
            }
            else
            {
                _logger.LogError($"The order with defined id = {id} is in progress now, you can't delete it");
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

            _logger.LogInformation("Order was successfully updated");

            return order;
        }

    }
}

