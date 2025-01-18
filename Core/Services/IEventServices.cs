using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Model;

namespace Kantinen.Services
{
    
    public interface IEvent
    {
        Task<List<Event>> GetAllAsync();
        Task<Event?> GetByIdAsync(string id);
        Task CreateAsync(Event newEvent);
        Task UpdateAsync(string id, Event updatedEvent);
        Task DeleteAsync(string id);
    }
}
