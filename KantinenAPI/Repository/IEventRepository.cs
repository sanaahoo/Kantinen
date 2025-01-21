using Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace KantinenAPI.Repository
{


    public interface IEventRepository
    {
        IEnumerable<Event> GetAllEvents();
        void AddEvent(Event evt);
      
        
    }
}