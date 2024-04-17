namespace ProEvents.Domain.Models
{
    public class Speaker{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string ImgUrl { get; set; }
        public string Telephone {get; set;}
        public string Email { get; set; } 
        public IEnumerable<SocialNetwork> SocialNetwork { get; set; }
        public IEnumerable<SpeakerEvent> SpeakerEvents { get; set; }
    }
}