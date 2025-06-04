namespace kolos2.DTOs;

public class PurchaseResponseDTO
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public List<PurchaseInfoDTO> Purchases { get; set; } = new();
}