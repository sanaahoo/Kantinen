using Core.Model;
using System.Collections.Generic;
using System.Linq;
using KantinenAPI.Repository;
using MongoDB.Driver;


public class EventRepository : IEventRepository
{
    private IMongoCollection<Event> _eventCollection;

    public EventRepository(){
        var client = new MongoClient("mongodb+srv://sanaa:9xRHv28k5gLVqjL5@cluster0.9rqsi.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
        var database = client.GetDatabase("kantinedb");
        _eventCollection = database.GetCollection<Event>("event_collection");
    }

    public async Task<IEnumerable<Event>> GetAllEvents() { 
        var filter = Builders<Event>.Filter.Empty;
        return await _eventCollection.Find(filter).ToListAsync();
    }

    public async Task AddEvent(Event evt) { 
        await _eventCollection.InsertOneAsync(evt);
    }
}

