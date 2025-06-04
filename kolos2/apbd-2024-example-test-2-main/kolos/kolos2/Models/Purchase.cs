using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace kolos2.Models;


[Table("Purchase")]
[PrimaryKey(nameof(TicketConcertId), nameof(CustomerId))]

public class Purchase

{

    [Key]
    public int TicketConcertId { get; set; }
    [Key]
    public int CustomerId { get; set; }
 
    public DateTime PurchaseDate { get; set; }
 
    [ForeignKey(nameof(TicketConcertId))]
    public Ticket_Concert TicketConcert { get; set; }
    [ForeignKey(nameof(CustomerId))]
    public Customer Customer { get; set; }

}