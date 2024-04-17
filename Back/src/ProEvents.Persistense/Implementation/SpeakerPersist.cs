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
    public class SpeakerPersist : ISpeakerPersist
    {
        private readonly ProEventsContext _context;

        public SpeakerPersist(ProEventsContext context)
        {
            _context = context;
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }


        public async Task<Speaker[]> GetAllSpeakersAsync(bool includeEvent = false)
        {
            IQueryable<Speaker> query = _context.Speakers.AsNoTracking();

            if (includeEvent)
            {
                query = query.Include(s => s.SpeakerEvents)
                              .ThenInclude(es => es.Event);
            }

            query = query.OrderBy(s => s.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Speaker[]> GetSpeakersByNameAsync(string name, bool includeEvent)
        {
            IQueryable<Speaker> query = _context.Speakers.AsNoTracking();

            if (includeEvent)
            {
                query = query.Include(s => s.SpeakerEvents)
                              .ThenInclude(es => es.Event);
            }

            query = query.OrderBy(s => s.Id).Where(s => s.Name.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Speaker> GetSpeakerByIdAsync(int speakerId, bool includeEvent)
        {
            IQueryable<Speaker> query = _context.Speakers.AsNoTracking();

            if (includeEvent)
            {
                query = query.Include(s => s.SpeakerEvents)
                              .ThenInclude(es => es.Event);
            }

            query = query.OrderBy(s => s.Id).Where(s => s.Id == speakerId);

            return await query.FirstOrDefaultAsync();
        }

        
    }
}
