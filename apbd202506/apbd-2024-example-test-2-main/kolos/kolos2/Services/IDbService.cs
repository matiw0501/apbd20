

using kolos2.DTOs;

namespace kolos2.Services;

public interface IDbService
{
   
    Task<PurchaseResponseDTO?> GetCustomerPurchasesAsync(int customerId);
    Task<(bool Success, string? ErrorMessage)> CreateCustomerWithPurchasesAsync(PurchaseRequestDTO dto);
}