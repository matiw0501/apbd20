using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apbdKolos2B.Models;


public class TicketConcert
{
    
    [Key]
    public int TicketConcertId { get; set; }
    [ForeignKey(nameof(Ticket))]
    public int TicketId { get; set; }
    [ForeignKey(nameof(Concert))]
    public int ConcertId { get; set; }
    [Precision(10,2)]
    public double Price { get; set; }
 
    public Ticket Ticket { get; set; }
    public Concert Concert { get; set; }
    
    public ICollection<PurchasedTicket> PurchasedTickets { get; set; }
    
}