using System.Net.Http.Json;
using Core.Model;

namespace Core.Services
{
    public class EventServices : IEventServices
    {
        private HttpClient _httpClient;

        public EventServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<Event>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Event>>("https://localhost:7086/api/events");
            return response;
            
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
