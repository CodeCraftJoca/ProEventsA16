using ProEvents.Application.Interface;
using ProEvents.Domain.Models;
using ProEvents.Persistense.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEvents.Application.Implementation
{
    public class EventService : IEventService
    {
        private readonly IGeneralPersist _generalPersist;
        private readonly IEventPersist _eventPersist;
        public EventService(IGeneralPersist generalPersist, IEventPersist eventPersist)
        {
            _eventPersist = eventPersist;
            _generalPersist = generalPersist;
        }
        public async Task<Event> AddEvent(Event model)
        {
            try
            {
                _generalPersist.Add<Event>(model);
                if (await _generalPersist.SaveChangesAsync())
                {
                    return await _eventPersist.GetEventByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Event> UpdateEvent(int eventId, Event model)
        {
            try
            {
                var eventUpdate = await _eventPersist.GetEventByIdAsync(eventId, false);
                if (eventUpdate == null) return null;

                model.Id = eventUpdate.Id;

                _generalPersist.Uppdate(model);

                if (await _generalPersist.SaveChangesAsync())
                {
                    return await _eventPersist.GetEventByIdAsync(model.Id, false);
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvent(int eventId)
        {
            try
            {
                var eventDelete = await _eventPersist.GetEventByIdAsync(eventId, false);
                if (eventDelete == null) throw new Exception("Event not Found");


                _generalPersist.Delete<Event>(eventDelete);
                return await _generalPersist.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Event[]> GetAllEventsAsync(bool includeSpeaker = false)
        {
            try
            {
               var events = await _eventPersist.GetAllEventsAsync(includeSpeaker);
                if (events == null) return null; 
                
                return events;
            }
            catch (Exception ex )
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeaker = false)
        {
            try
            {
                var events = await _eventPersist.GetAllEventsByThemeAsync(theme, includeSpeaker);
                if (events == null) return null;

                return events;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Event> GetEventByIdAsync(int eventId, bool includeSpeaker = false)
        {
            try
            {
                var getEvent = await _eventPersist.GetEventByIdAsync(eventId, includeSpeaker);
                if (getEvent == null) return null;

                return getEvent;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

       
    }
}
