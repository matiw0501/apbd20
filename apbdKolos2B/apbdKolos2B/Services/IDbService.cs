using apbdKolos2B.DTOs;

namespace apbdKolos2B.Database;

public interface IDbService
{
    public Task<CustomerPurchasesDTO> GetPurchases(int id);

    public Task AddCustomer(AddCustomer addCustomer);
};