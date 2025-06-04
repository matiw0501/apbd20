using System.ComponentModel.DataAnnotations;

namespace kolos2.Models;

public class Purchase
{
    [Key]
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Price { get; set; }

    public int TicketId { get; set; }
    public Ticket Ticket { get; set; } = null!;

    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
}