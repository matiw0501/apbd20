using System.ComponentModel.DataAnnotations;

namespace apbdKolos2B.DTOs;

public class AddCustomer
{
    [Required]
    public AddCustomerDTO Customer { get; set; }
    [Required]
    public List<AddPurchaseDTO> Purchases { get; set; }
}

public class AddCustomerDTO
{
    [Required]
    public int CustomerId { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string? Phone { get; set; }
}

public class AddPurchaseDTO
{
    [Required]
    public int SeatNumber { get; set; }
    [Required]
    public string ConcertName {get; set;}
    [Required]
    public double Price { get; set; }
}