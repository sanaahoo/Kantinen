using System.Net.Http.Json;
using Core.Model;

namespace Core.Services
{
    public class EventServices: IEventServices

    {
 
    public async Task<List<Event>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Event?> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task CreateAsync(Event newEvent)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(string id, Event updatedEvent)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }
    }
}
