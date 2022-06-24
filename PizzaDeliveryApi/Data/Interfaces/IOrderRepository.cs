using PizzaDeliveryApi.Data.Models;

namespace PizzaDeliveryApi.Data.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task<Order> CreateOrderAsync(Order order);

        Task<Order> EditOrderByIdAsync(int id, Order order);
        Task DeleteOrderByIdAsync(int id);
    }
}
