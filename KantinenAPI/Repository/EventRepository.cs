using Core.Model;
using System.Collections.Generic;
using System.Linq;
using KantinenAPI.Repository;


public class EventRepository : IEventRepository

{
    private readonly List<Event> _events = new List<Event>();

    public IEnumerable<Event> GetAllEvents() => _events;

    public void AddEvent(Event evt) => _events.Add(evt);
}

