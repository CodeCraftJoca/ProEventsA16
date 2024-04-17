using Microsoft.EntityFrameworkCore;
using ProEvents.Domain.Models;
using ProEvents.Persistense.Data;
using ProEvents.Persistense.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProEvents.Persistense.Implementation
{
    public class EventPersist : IEventPersist
    {
        private readonly ProEventsContext _context;

        public EventPersist(ProEventsContext context)
        {
            _context = context;
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }


        //Events
        public async Task<Event[]> GetAllEventsAsync(bool includeSpeaker = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Batch)
                .Include(e => e.SocialNetwork);

            if (includeSpeaker)
            {
                query = query
                    .Include(e => e.SpeakerEvents)
                    .ThenInclude(es => es.Speaker);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Event> GetEventByIdAsync(int eventId, bool includeSpeaker = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Batch)
                .Include(e => e.SocialNetwork);

            if (includeSpeaker)
            {
                query = query
                    .Include(e => e.SpeakerEvents)
                    .ThenInclude(es => es.SpeakerId);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id)
                         .Where(e => e.Id == eventId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeaker = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Batch)
                .Include(e => e.SocialNetwork);

            if(includeSpeaker)
            {
                query = query.Include(e => e.SpeakerEvents)
                    .ThenInclude(es => es.SpeakerId);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id)
                .Where(e => e.Theme.ToLower().Contains(theme.ToLower()));

            return await query.ToArrayAsync();
        }
        
    }
}
