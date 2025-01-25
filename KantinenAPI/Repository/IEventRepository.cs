using Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace KantinenAPI.Repository

{
    public interface IEventRepository
    {
        // Henter alle begivenheder
        Task<IEnumerable<Event>> GetAllEvents();

        // Tilføjer en ny begivenhed
        Task AddEvent(Event evt);
    }
}