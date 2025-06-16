using apbdKolo2A.Exceptions;
using apbdKolo2A.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace apbdKolo2A.Controllers;



[ApiController]
[Route("api/customers")]
public class CustomerPurcharsesController : ControllerBase
{
    
    private readonly IDbService _dbService;

    public CustomerPurcharsesController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}/purchases")]
    public async Task<IActionResult> GetPurchases(int id)
    {
        try
        {
           var purchases = await _dbService.GetPurchases(id);
           return Ok(purchases);
        }
        catch (NotFoundException e)
        {
           return NotFound(e.Message);
        }
    }

}