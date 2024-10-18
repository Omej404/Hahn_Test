using System.ComponentModel.DataAnnotations;

namespace HahnApp_MEJRHIRROU.Models
{
    public class Ticket
    {
        [Key]
        public Guid Ticket_Id { get; set; }
        public required string Description { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
    }
}
