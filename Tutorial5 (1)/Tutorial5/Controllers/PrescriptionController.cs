﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tutorial5.Data;
using Tutorial5.DTOs;
using Tutorial5.Models;
using Tutorial5.Services;

namespace Tutorial5.Controllers;
[Route("api/prescriptions")]
[ApiController]

public class PrescriptionController : ControllerBase
{
    private readonly IDbService _dbService;
    
    
    public PrescriptionController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    public async Task<IActionResult> AddPrescription([FromBody] PrescriptionMedicamentDTO prescription)
    {
        if (prescription.Medicaments.Count > 10 || prescription.Medicaments.Count < 1)
            return BadRequest("Bad amount medicaments per prescription. Can't be more than 10 and less than 1");
        if (prescription.DueDate.Date < prescription.Date.Date)
            return BadRequest("Due date can't be before prescription date");

        try
        {
            await _dbService.AddPrescriptionMedicament(prescription);
            return Created();
        }
        catch (InvalidDataException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}