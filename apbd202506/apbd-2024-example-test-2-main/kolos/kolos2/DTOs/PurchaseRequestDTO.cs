namespace kolos2.DTOs;

public class PurchaseRequestDTO
{
    public CustomerDTO Customer { get; set; } = null!;
    public List<PurchaseInputDTO> Purchases { get; set; } = new();
}