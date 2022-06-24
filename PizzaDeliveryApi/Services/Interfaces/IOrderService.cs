using PizzaDeliveryApi.Data.DTOModels;

namespace PizzaDeliveryApi.Services.Interfaces
{
    public interface IOrderService
    {
        Task MakeOrder(OrderDTO orderDto);
        Task DeleteOrderByIdAsync(int id);
    }
}
