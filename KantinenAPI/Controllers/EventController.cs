using Core.Model;
using Microsoft.AspNetCore.Mvc;
using Core.Services;
using KantinenAPI.Repository;

namespace KantinenAPI.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _repository;

        public EventsController(IEventRepository repository)
        {
            _repository = repository;
        }

        // GET: api/events
        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _repository.GetAllEvents();
            return Ok(events);
        }

        // POST: api/events
        [HttpPost]
        public IActionResult AddEvent( Event evt)
        {
            if (evt == null)
            {
                return BadRequest("Invalid event data.");
            }

            _repository.AddEvent(evt);
            return CreatedAtAction(nameof(GetEvents), new { id = evt.Id }, evt);
        }
    }
}