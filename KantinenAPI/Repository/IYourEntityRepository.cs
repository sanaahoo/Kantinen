using MongoDB.Driver;
using Core.Model;



public interface IYourEntityRepository
{
    Task<List<YourEntity>> GetAllAsync();
    Task<YourEntity> GetByIdAsync(string id);
    Task CreateAsync(YourEntity entity);
    Task UpdateAsync(string id, YourEntity entity);
    Task DeleteAsync(string id);
}