using MongoDB.Bson;
using Core.Model;


public class YourServices
{
    private readonly IYourEntityRepository _repository;

    public YourService(IYourEntityRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<YourEntity>> GetEntitiesAsync()
    {
        return await _repository.GetAllAsync();
    }
}