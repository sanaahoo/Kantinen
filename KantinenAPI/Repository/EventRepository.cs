using Core.Model;
using System.Collections.Generic;
using System.Linq;
using KantinenAPI.Repository;
using MongoDB.Driver;

public class EventRepository : IEventRepository
{
    private IMongoCollection<Event> _eventCollection; // MongoDB-samling til begivenheder

    // Constructor der initialiserer MongoDB-klient og database
    public EventRepository()
    {
        var client = new MongoClient("mongodb+srv://sanaa:9xRHv28k5gLVqjL5@cluster0.9rqsi.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
        var database = client.GetDatabase("kantinedb");
        _eventCollection = database.GetCollection<Event>("event_collection"); // Henter event-samlingen
    }

    // Henter alle begivenheder fra MongoDB
    public async Task<IEnumerable<Event>> GetAllEvents()
    {
        var filter = Builders<Event>.Filter.Empty; // Ingen filter, henter alle begivenheder
        return await _eventCollection.Find(filter).ToListAsync(); // Returnerer en liste af begivenheder
    }

    // Tilføjer en ny begivenhed til MongoDB
    public async Task AddEvent(Event evt)
    {
        await _eventCollection.InsertOneAsync(evt); // Indsætter begivenheden i samlingen
    }
}



























