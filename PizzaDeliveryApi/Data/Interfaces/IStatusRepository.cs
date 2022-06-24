using PizzaDeliveryApi.Data.Models;

namespace PizzaDeliveryApi.Data.Interfaces
{
    public interface IStatusRepository
    {
        Task<List<Status>> GetAllStatusesAsync();
        Task<Status> GetStatusByIdAsync(int id);
        Task<Status> CreateStatusAsync(Status status);

        Task<Status> EditStatusByIdAsync(int id, Status status);
        Task DeleteStatusByIdAsync(int id);
    }
}
