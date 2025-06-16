using apbdKolos2B.Database;
using apbdKolos2B.DTOs;
using apbdKolos2B.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace apbdKolos2B.Controllers;


[ApiController]
public class ClientPurchases : ControllerBase
{
    
    private readonly IDbService _dbService;

    public ClientPurchases(IDbService dbService)
    {
        _dbService = dbService;
    }


    [HttpGet("api/customers/{id}/purchases")]
    public async Task<IActionResult> GetPurchases(int id)
    {
        try
        {
            var  customerPurchases =await  _dbService.GetPurchases(id);
            return Ok(customerPurchases);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost("customers")]
    public async Task<IActionResult> AddCustomer(AddCustomer customerDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _dbService.AddCustomer(customerDTO);
            return Ok();
        }
        catch (ConflictException e)
        {
            return Conflict(e.Message);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


}