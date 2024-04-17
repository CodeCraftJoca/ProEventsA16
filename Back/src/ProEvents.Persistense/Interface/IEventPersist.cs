using ProEvents.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEvents.Persistense.Interface
{
    public interface IEventPersist
    {
        Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeaker = false);
        Task<Event[]> GetAllEventsAsync( bool includeSpeaker = false);
        Task<Event> GetEventByIdAsync(int eventId, bool includeSpeaker = false);
    }
}
