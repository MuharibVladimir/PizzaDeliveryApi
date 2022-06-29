using PizzaDeliveryApi.Data.DTOModels;
using PizzaDeliveryApi.Data.Interfaces;
using PizzaDeliveryApi.Data.Models;

namespace PizzaDeliveryApi.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> MakeOrderAsync(OrderDTO orderDto);

        Task<List<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);

        Task<Order> EditOrderByIdAsync(int id, OrderDTO order);
        Task DeleteOrderByIdAsync(int id);
        Task<List<Order>> GetOrdersByStatusNameAsync(string status);
        Task<List<Order>> GetOrdersByCustomerIdAsync(int id);
        Task<List<Order>> GetOrdersInPriceRangeIdAsync(decimal upperBoundary, decimal lowBoundary);
        Task<int> GetOrdersByStreetAsync(string street);
    }
}
