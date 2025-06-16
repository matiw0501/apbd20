using System.ComponentModel.DataAnnotations;

namespace apbdKolos2B.Models;

public class Ticket
{
    [Key]
    public int TicketId { get; set; }
    [MaxLength(50)]
    public string SerialNumber { get; set; }
    public int SeatNumber { get; set; }
    
    
    public ICollection<TicketConcert> TicketConcerts { get; set; }
}