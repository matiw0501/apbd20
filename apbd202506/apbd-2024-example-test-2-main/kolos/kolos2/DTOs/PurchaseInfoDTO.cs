namespace kolos2.DTOs;

public class PurchaseInfoDTO
{
    public DateTime Date { get; set; }
    public decimal Price { get; set; }
    public TicketDTO Ticket { get; set; } = null!;
    public ConcertDTO Concert { get; set; } = null!;
}