using apbdKolos2ProbnyTest.Database;
using Microsoft.AspNetCore.Mvc;

namespace apbdKolos2ProbnyTest.Controllers;
[ApiController]

public class Controller : ControllerBase
{
    private readonly IDbService _dbService;

    public Controller(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    


}