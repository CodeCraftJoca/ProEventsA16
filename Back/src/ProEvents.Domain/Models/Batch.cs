using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProEvents.Domain.Models
{
    public class Batch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Quantity { get; set; }
        public int EventId { get; set; }
        
        public Event? Event { get; set; }

    }
}