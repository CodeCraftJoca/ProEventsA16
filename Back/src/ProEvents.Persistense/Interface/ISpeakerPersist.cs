using ProEvents.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEvents.Persistense.Interface
{
    public interface ISpeakerPersist
    {
        //Speakers
        Task<Speaker[]> GetSpeakersByNameAsync(string name, bool includeEvent);
        Task<Speaker[]> GetAllSpeakersAsync(bool includeEvent);
        Task<Speaker> GetSpeakerByIdAsync(int speakerId, bool includeEvent);


    }
}
