using Core.Model;
using Microsoft.AspNetCore.Mvc;
using Core.Model.Services;

namespace KantinenAPI.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventsController : ControllerBase
    {
        private readonly IEventsService _service;

        public EventsController(IEventsService service)
        {
            _service = service;
        }

        // GET: api/events
        [HttpGet]
        public IActionResult GetEvents()
        {
            var events = _service.GetEvents();
            return Ok(events);
        }

        // POST: api/events
        [HttpPost]
        public IActionResult AddEvent([FromBody] Events evt)
        {
            if (evt == null)
            {
                return BadRequest("Invalid event data.");
            }

            _service.AddEvent(evt);
            return CreatedAtAction(nameof(GetEvents), new { id = evt.Id }, evt);
        }
    }
}