using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProEvents.Application.Interface;
using ProEvents.Domain.Models;

namespace ProEvents.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService eventService;

        public EventController(IEventService _eventService)
        {
            this.eventService = _eventService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var events = await eventService.GetAllEventsAsync(true);
                if (events == null) return NotFound("Events not found");

                return Ok(events);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error when trying to retrieve events");
            }
        }

        [HttpGet("{theme}")]
        public async Task<IActionResult> GetByTheme(string theme)
        {
            try
            {
                var getEvent = await eventService.GetAllEventsByThemeAsync(theme, true);
                if (getEvent == null) return NotFound("Event not found");

                return Ok(getEvent);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error when trying to retrieve events error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                var getEvent = await eventService.GetEventByIdAsync(Id, true);
                if (getEvent == null) return NotFound("Event not found");

                return Ok(getEvent);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error when trying to retrieve events error: {ex.Message}");

            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Event Modal)
        {
            try
            {
                var eventAdd = await eventService.AddEvent(Modal);
                if (eventAdd == null) return BadRequest("Error when trying to add the event");

                return Ok(eventAdd);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error when trying to retrieve events error: {ex.Message}");
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, [FromBody]Event model)
        {
            try
            {
                var eventAdd = await eventService.UpdateEvent(Id, model);
                if (eventAdd == null) return BadRequest("Error when trying to update the event");

                return Ok(eventAdd);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error when trying to update events error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
              return  await eventService.DeleteEvent(Id) ? Ok("Deleted") : BadRequest("Event not deleted");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error when trying to update events error: {ex.Message}");
            }
        }
    }
}
