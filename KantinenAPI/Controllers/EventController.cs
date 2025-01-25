using Core.Model;
using Microsoft.AspNetCore.Mvc;
using Core.Services;
using KantinenAPI.Repository;

namespace KantinenAPI.Controllers
{
    [ApiController]
    [Route("api/events")] // Basisruten for alle endpoints i denne controller
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _repository; // Repository til håndtering af begivenheder

        // Constructor der injicerer IEventRepository
        public EventsController(IEventRepository repository)
        {
            _repository = repository;
        }

        // Henter alle begivenheder
        [HttpGet]
        [Route("getEvents")]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _repository.GetAllEvents(); // Henter alle begivenheder fra repository
            return Ok(events); // Returnerer begivenheder med HTTP 200 OK
        }

        // Tilføjer en ny begivenhed
        [HttpPost]
        [Route("addEvent")]
        public async Task<IActionResult> AddEvent(Event evt)
        {
            if (evt == null) // Tjekker om begivenheden er gyldig
            {
                return BadRequest("Invalid event data."); // Returnerer HTTP 400 ved ugyldig data
            }

            await _repository.AddEvent(evt); // Tilføjer begivenheden til repository
            return Ok(); // Returnerer HTTP 200 OK
        }
    }
}