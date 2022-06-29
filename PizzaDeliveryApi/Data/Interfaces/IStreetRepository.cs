using PizzaDeliveryApi.Data.Models;

namespace PizzaDeliveryApi.Data.Interfaces
{
    public interface IStreetRepository/*: IEntityRepository<Street>*/
    {
        Task<List<Street>> GetAllStreetsAsync();
        Task<Street> GetStreetByIdAsync(int id);
        Task<Street> CreateStreetAsync(Street street);

        Task<Street> EditStreetByIdAsync(int id, Street street);
        Task DeleteStreetByIdAsync(int id);
    }
}

