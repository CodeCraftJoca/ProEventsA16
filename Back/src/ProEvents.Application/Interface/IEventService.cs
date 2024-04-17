using ProEvents.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEvents.Application.Interface
{
    public interface IEventService
    {
        Task<Event> AddEvent(Event model);
        Task<Event> UpdateEvent(int eventId, Event model);
        Task<bool> DeleteEvent(int eventId);

        Task<Event[]> GetAllEventsAsync(bool includeSpeaker = false);
        Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeaker = false);
        Task<Event> GetEventByIdAsync(int eventId, bool includeSpeaker = false);
    }
}
