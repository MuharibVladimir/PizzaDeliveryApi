using PizzaDeliveryApi.Data.Models;

namespace PizzaDeliveryApi.Data.Interfaces
{
    public interface IOrderProductRepository
    {
        Task<List<OrderProduct>> GetAllOrderProductsAsync();
        Task<OrderProduct> GetOrderProductByIdAsync(int id);
        Task<OrderProduct> CreateOrderProductAsync(OrderProduct orderProduct);

        Task<OrderProduct> EditOrderProductByIdAsync(int id, OrderProduct orderProduct);
        Task DeleteOrderProductByIdAsync(int id);
    }
}
