using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolos2.Models;

public class Ticket_Concert
{
    [Key]
    public int TicketConcertId { get; set; }
 
    public int TicketId { get; set; }
    public int ConcertId { get; set; }
    
    public decimal Price { get; set; }
 
    [ForeignKey(nameof(TicketId))]
    public Ticket Ticket { get; set; } = null!;
 
    [ForeignKey(nameof(ConcertId))]
    public Concert Concert { get; set; } = null!;
 
    public ICollection<Purchase> PurchasedTickets { get; set; } = new List<Purchase>();
}