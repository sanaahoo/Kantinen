using Core.Model;
using System.Collections.Generic;
using System.Linq;
using KantinenAPI.Repositories;


public class EventsRepository : IEventsRepository
{
    private readonly List<Events> _events = new List<Events>();

    public IEnumerable<Events> GetAll() => _events;

    public void Add(Events evt) => _events.Add(evt);
}

