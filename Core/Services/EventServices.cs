using System.Net.Http.Json;
using Core.Model;

namespace Core.Services
{
    public class EventServices : IEventServices
    {
        private HttpClient _httpClient; // HttpClient til at foretage HTTP-anmodninger

        // Constructor der injicerer HttpClient
        public EventServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Henter alle begivenheder fra API'et
        public async Task<List<Event>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Event>>("https://localhost:7086/api/events/getEvents");
            return response; // Returnerer listen af begivenheder
        }

        // Henter en begivenhed ud fra ID (ikke implementeret)
        public async Task<Event?> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        // Opretter en ny begivenhed via API'et
        public async Task CreateAsync(Event newEvent)
        {
            await _httpClient.PostAsJsonAsync("https://localhost:7086/api/events/addEvent", newEvent);
        }

        // Opdaterer en eksisterende begivenhed (ikke implementeret)
        public async Task UpdateAsync(string id, Event updatedEvent)
        {
            throw new NotImplementedException();
        }

        // Sletter en begivenhed (ikke implementeret)
        public async Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
