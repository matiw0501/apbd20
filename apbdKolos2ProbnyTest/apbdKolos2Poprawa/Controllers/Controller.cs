using apbdKolos2ProbnyTest.Database;
using apbdKolos2ProbnyTest.DTOs;
using apbdKolos2ProbnyTest.Exceptions;
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

    [HttpGet("api/characters/{characterId}")]
    public async Task<IActionResult> GetCharacter([FromRoute] int characterId)
    {
        try
        {
            var character = await _dbService.GetCharacter(characterId);
            return Ok(character);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ConflictException ex)
        {
            return Conflict(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("api/characters/{characterId}/backpacks")]
    public async Task<IActionResult> AddEq(int characterId ,ListDTO listDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _dbService.AddEq(characterId, listDTO);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ConflictException e)
        {
            return Conflict(e.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


}