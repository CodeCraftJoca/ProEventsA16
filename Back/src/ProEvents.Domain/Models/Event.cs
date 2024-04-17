using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ProEvents.Domain.Models;

namespace ProEvents.Domain.Models
{
    public class Event
    {
        public int Id { get; set; }    
        public string Local { get; set; }
        public DateTime? EventDate { get; set; }
        public string Theme { get; set; }
        public int NumberOfPeople { get; set; }
        public string ImgUrl { get; set; }  
        public string Telephone {get; set;}
        public string Email { get; set; }
        public IEnumerable<Batch>? Batch { get; set; }
        public IEnumerable<SocialNetwork>? SocialNetwork { get; set; }
        public IEnumerable<SpeakerEvent>? SpeakerEvents { get; set; }

    }

}