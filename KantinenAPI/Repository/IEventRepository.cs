using Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace KantinenAPI.Repository
{


    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task AddEvent(Event evt);
      
        
    }
}