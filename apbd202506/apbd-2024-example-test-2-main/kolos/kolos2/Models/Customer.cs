using System.ComponentModel.DataAnnotations;

namespace kolos2.Models;

public class Customer
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }

    public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}