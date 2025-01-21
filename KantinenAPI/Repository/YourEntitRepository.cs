using MongoDB.Driver;
using Core.Model;


public class YourEntityRepository : IYourEntityRepository
{
    private readonly IMongoCollection<YourEntity> _collection;

    public YourEntityRepository(IMongoClient client, IOptions<MongoDBSettings> settings)
    {
        var database = client.GetDatabase(settings.Value.DatabaseName);
        _collection = database.GetCollection<YourEntity>("YourEntities");
    }

    public async Task<List<YourEntity>> GetAllAsync() =>
        await _collection.Find(entity => true).ToListAsync();

    public async Task<YourEntity> GetByIdAsync(string id) =>
        await _collection.Find(entity => entity.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(YourEntity entity) =>
        await _collection.InsertOneAsync(entity);

    public async Task UpdateAsync(string id, YourEntity entity) =>
        await _collection.ReplaceOneAsync(e => e.Id == id, entity);

    public async Task DeleteAsync(string id) =>
        await _collection.DeleteOneAsync(e => e.Id == id);
}