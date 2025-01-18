using Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace KantinenAPI.Repositories
{


    public interface IEventsRepository
    {
        IEnumerable<Events> GetAll();
        void Add(Events evt);
    }
}