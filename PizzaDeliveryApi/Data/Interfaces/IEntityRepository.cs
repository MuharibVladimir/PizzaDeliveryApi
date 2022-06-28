namespace PizzaDeliveryApi.Data.Interfaces
{
    public interface IEntityRepository<T> where T : class
    {
        Task<List<T>> GetAllEntitiesAsync();
        Task<T> GetEntityByIdAsync(int id);
        Task<T> CreateEntityAsync(T entity);
        Task<T> EditEntityByIdAsync(int id, T entity);
        Task DeleteEntityByIdAsync(int id);
    }
}
