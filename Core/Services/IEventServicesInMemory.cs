using System.Net.Http.Json;
using Core.Model;

namespace Kantinen.Services
{
    public class EventServiceInMemory : IEvent
    {
        private readonly List<Event> _events = new();

        public Task<List<Event>> GetAllAsync()
        {
            return Task.FromResult(_events);
        }

        public Task<Event?> GetByIdAsync(string id)
        {
            var ev = _events.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(ev);
        }

        public Task CreateAsync(Event newEvent)
        {
            newEvent.Id = Guid.NewGuid().ToString(); // Generate a unique ID
            _events.Add(newEvent);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(string id, Event updatedEvent)
        {
            var index = _events.FindIndex(e => e.Id == id);
            if (index != -1)
            {
                _events[index] = updatedEvent;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id)
        {
            var ev = _events.FirstOrDefault(e => e.Id == id);
            if (ev != null)
            {
                _events.Remove(ev);
            }
            return Task.CompletedTask;
        }
    }
}