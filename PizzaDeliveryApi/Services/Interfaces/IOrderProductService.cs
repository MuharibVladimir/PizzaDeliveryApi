using PizzaDeliveryApi.Data.DtoModels;
using PizzaDeliveryApi.Data.Models;

namespace PizzaDeliveryApi.Services.Interfaces
{
    public interface IOrderProductService
    {
        Task<List<OrderProduct>> GetAllOrderProductsAsync();
        Task<OrderProduct> GetOrderProductByIdAsync(int id);
        Task<OrderProduct> CreateOrderProductAsync(OrderProductDTO orderProductDto);

        Task<OrderProduct> EditOrderProductByIdAsync(int id, OrderProductDTO orderProductDto);
        Task DeleteOrderProductByIdAsync(int id);
    }
}
