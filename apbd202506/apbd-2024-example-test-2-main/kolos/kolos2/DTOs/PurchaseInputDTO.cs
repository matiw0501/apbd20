namespace kolos2.DTOs;

public class PurchaseInputDTO
{
    public int SeatNumber { get; set; }
    public string ConcertName { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
