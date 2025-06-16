using apbdKolo2A.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace apbdKolo2A.Services;

public interface IDbService
{
    public Task<ClientOrdersDTO> GetPurchases(int id);
    public Task AddWashingMachineAndAvaPrograms(AddWashingMachineDTO addWashingMachineDTO);
}