using System.Net.Http.Json;
using Core.Model;

namespace Core.Services
{
    public class EventServices: IEventServices

    {
 
    public Task<List<Event>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Event?> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(Event newEvent)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(string id, Event updatedEvent)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }
    }
}
