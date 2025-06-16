using Probny2025ZRozwiazaniem.Models;

namespace Probny2025ZRozwiazaniem.DTOs;

public class OrdersDTO
{
    public int OrderId { get; set; }
    public DateTime OrderedAt { get; set; }
    public DateTime? FulfilledAt { get; set; }
    public string Status { get; set; } = null!;
    public ClientInfo ClientInfo { get; set; } = null!;
    public List<ProductAmount> Products { get; set; } = null!;
    
}

public class ClientInfo
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}

public class ProductAmount
{
    public string ProductName { get; set; } = null!;
    public double ProductPrice { get; set; }
    public int Amount { get; set; }
}