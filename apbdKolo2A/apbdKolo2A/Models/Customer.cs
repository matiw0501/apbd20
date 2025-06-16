using System.ComponentModel.DataAnnotations;

namespace apbdKolo2A.Models;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    [MaxLength(100)]
    public string? PhoneNumber { get; set; }

    public ICollection<PurchaseHistory> PurchaseHistories { get; set; } = null!;
}