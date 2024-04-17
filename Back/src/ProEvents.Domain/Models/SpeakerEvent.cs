namespace ProEvents.Domain.Models
{
    public class SpeakerEvent
    {
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int SpeakerId { get; set; }
        public Speaker Speaker { get; set; }
        
    }
}