using Core.Model;
using System.Collections.Generic;
using System.Linq;
using KantinenAPI.Repository;
using MongoDB.Driver;


public class EventRepository : IEventRepository
{
    private IMongoCollection<Event> _eventCollection;

    public EventRepository(){
        var client = new MongoClient("mongodb://localhost/Kantinen");
        var database = client.GetDatabase("Kantinen");
        _eventCollection = database.GetCollection<Event>("Event");
    }

    public async Task<IEnumerable<Event>> GetAllEvents() { 
        var filter = Builders<Event>.Filter.Empty;
        return await _eventCollection.Find(filter).ToListAsync();
    }

    public async Task AddEvent(Event evt) { 
        await _eventCollection.InsertOneAsync(evt);
    }
}

