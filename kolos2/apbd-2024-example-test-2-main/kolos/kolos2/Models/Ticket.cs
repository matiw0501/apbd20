using System.ComponentModel.DataAnnotations;

namespace kolos2.Models;

public class Ticket

{

    [Key]

    public int TicketId { get; set; }
 
    [MaxLength(50)]

    public string SerialNumber { get; set; } = null!;

    public int SeatNumber { get; set; }
 
    public ICollection<Ticket_Concert> TicketConcerts { get; set; } = new List<Ticket_Concert>();

}