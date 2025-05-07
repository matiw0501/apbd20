using APBD_example_test1_2025.Exceptions;
using APBD_example_test1_2025.Models.DTOs;
using APBD_example_test1_2025.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_example_test1_2025.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentsController : ControllerBase
{
    private readonly IDbService _dbService;

    public AppointmentsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAppointment(int id)
    {
        try
        {
            var appointment = await _dbService.GetAppointmentByIdAsync(id);
            return Ok(appointment);
        }
        catch (NotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddAppointment(CreateAppointmentDto dto)
    {
        if (!dto.Services.Any())
            return BadRequest("At least one service is required.");

        try
        {
            await _dbService.AddAppointmentAsync(dto);
            return CreatedAtAction(nameof(GetAppointment), new { id = dto.AppoitmentId }, dto);
        }
        catch (NotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
        catch (ConflictException e)
        {
            return Conflict(new { message = e.Message });
        }
    }
}