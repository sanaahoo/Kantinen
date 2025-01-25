using Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IEventServices
    {
        // Henter alle begivenheder
        Task<List<Event>> GetAllAsync();

        // Henter en begivenhed ud fra ID
        Task<Event?> GetByIdAsync(string id);

        // Opretter en ny begivenhed
        Task CreateAsync(Event newEvent);

        // Opdaterer en eksisterende begivenhed
        Task UpdateAsync(string id, Event updatedEvent);

        // Sletter en begivenhed
        Task DeleteAsync(string id);
    }
}