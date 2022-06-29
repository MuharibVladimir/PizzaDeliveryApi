using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        private readonly DataContext _context;

        public OrderService(IOrderRepository orders, IMapper mapper, ILogger<IOrderService> logger, DataContext context)
        {
            _orders = orders;    
            _mapper = mapper;
            _logger = logger;  
            _context = context;
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

        public async Task<List<Order>> GetOrdersByStatusNameAsync(string status)
        {
            return await _context.Orders.Where(o => o.Status.Name == status).ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByCustomerIdAsync(int id)
        {
            return await _context.Orders.Where(o => o.CustomerId == id).ToListAsync();
        }

        public async Task<List<Order>> GetOrdersInPriceRangeIdAsync(decimal upperBoundary, decimal lowBoundary)
        {
            return await _context.Orders.Where(o => (o.TotalPrice < upperBoundary) && (o.TotalPrice > lowBoundary)).ToListAsync();
        }

        public async Task<int> GetOrdersByStreetAsync(string street)
        {
            var orders = await _context.Orders.Where(o => o.Address.Street.Name == street).ToListAsync();

            return orders.Count;
        }

    }
}

