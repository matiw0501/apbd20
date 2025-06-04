using System.ComponentModel.DataAnnotations;

namespace kolos2.Models;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }
 
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? PhoneNumber { get; set; }
 
    public ICollection<Purchase> PurchasedTickets { get; set; } = new List<Purchase>();
}