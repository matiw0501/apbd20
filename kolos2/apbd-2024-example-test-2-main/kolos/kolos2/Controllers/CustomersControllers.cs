using kolos2.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolos2.Controllers;


[Route("api/[customers]")]
[ApiController]
public class CustomersControllers :ControllerBase
{
    private readonly IDbService _dbService;

    public CustomersControllers(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    
   
    
}