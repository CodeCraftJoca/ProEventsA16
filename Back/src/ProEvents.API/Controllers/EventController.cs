using System.Collections;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProEvents.API.Data;
using ProEvents.API.Models;

namespace ProEvents.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController : ControllerBase
{
    private readonly DataContext _context;

    public EventController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Event> Get()
    {
        return _context.Events;
    }

    [HttpGet("{id}")]
    public Event GetById(int id)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return _context.Events.FirstOrDefault(e => e.EventId == id);
#pragma warning restore CS8603 // Possible null reference return.
    }

    [HttpPost]
    public string Post()
    {
        string value = "0";
        return value;
    }

    [HttpPut]
    public string Put()
    {
        string value = "0";
        return value;
    }

    [HttpDelete]
    public string Delete()
    {
        string value = "0";
        return value;
    }
}
