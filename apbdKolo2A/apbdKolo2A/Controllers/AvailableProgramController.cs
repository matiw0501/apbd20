using apbdKolo2A.DTOs;
using apbdKolo2A.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbdKolo2A.Controllers;



[ApiController]
public class AvailableProgramController : ControllerBase
{
    
    private readonly IDbService _dbService;

    public AvailableProgramController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost("washing-mashines")]
    public async Task<IActionResult> WashingMashines(AddWashingMachineDTO addWashingMachineDTO)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _dbService.AddWashingMachineAndAvaPrograms(addWashingMachineDTO);
            return Ok();
        }
        catch (Exception ex)
        {
        return BadRequest(ex);    
        }
        
    }


}