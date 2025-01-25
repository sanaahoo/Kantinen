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

        [HttpGet]
        [Route("getEvents")]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _repository.GetAllEvents();
            return Ok(events);
        }

        [HttpPost]
        [Route("addEvent")]
        public async Task<IActionResult> AddEvent( Event evt)
        {
            if (evt == null)
            {
                return BadRequest("Invalid event data.");
            }

            await _repository.AddEvent(evt);
            return Ok();
        }
        
    }
}
