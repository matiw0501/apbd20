using apbdKolo2A.Database;
using apbdKolo2A.DTOs;
using apbdKolo2A.Exceptions;
using apbdKolo2A.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apbdKolo2A.Services;

public class DbService : IDbService
{
    
    private readonly DatabaseContext _context;


    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<ClientOrdersDTO> GetPurchases(int id)
    {
        var purcharses = await _context.Customers.Where(c => c.CustomerId == id).Select(e => new ClientOrdersDTO
        {
            FirstName = e.FirstName,
            LastName = e.LastName,
            PhoneNumber = e.PhoneNumber,
            Purchases = e.PurchaseHistories.Select(a => new PurchaseDTO()
            {
                Date = a.PurchaseDate,
                Rating = a.Rating,
                Price = a.AvailableProgram.Price,
                WashingMachine = new WashingMachineDTO()
                {
                    SerialNumber = a.AvailableProgram.WashingMachine.SerialNumber,
                    MaxWeight = a.AvailableProgram.WashingMachine.MaxWeight,
                },
                Program = new ProgramDTO()
                {
                    Name = a.AvailableProgram.Program.Name,
                    Duration = a.AvailableProgram.Program.DurationMinutes
                }
                
                
                
                
            }).ToList()
            
        }).FirstOrDefaultAsync();
        
        if (purcharses is null)
            throw new NotFoundException("Customer not found");
        
        
        return purcharses;
    }

    public async Task AddWashingMachineAndAvaPrograms(AddWashingMachineDTO addWashingMachineDTO)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var exist = await _context.WashingMachines.AnyAsync(mach =>
                mach.SerialNumber == addWashingMachineDTO.WashingMachine.SerialNumber);

            if (exist)
            {
                throw new ConflictException("Washing machine already exists");
            }

            var reqProgramNames = addWashingMachineDTO.AvailablePrograms.Select(prog => prog.ProgramName).ToList();
            var existProgramNames = await _context.Programs
                .Where(prog => reqProgramNames.Contains(prog.Name)).ToListAsync();
            if (existProgramNames.Count != reqProgramNames.Count)
            {
                throw new ConflictException("Some programs do not exist");
            }

            var washingMachine = new WashingMachine()
            {
                SerialNumber = addWashingMachineDTO.WashingMachine.SerialNumber,
                MaxWeight = addWashingMachineDTO.WashingMachine.MaxWeight,
                AvailablePrograms = addWashingMachineDTO.AvailablePrograms.Select(a => new AvailableProgram()
                {
                    Price = a.price,
                    ProgramId = existProgramNames.FirstOrDefault(prog => prog.Name == a.ProgramName).ProgramId,
                }).ToList()
            };

            _context.WashingMachines.Add(washingMachine);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
             await transaction.RollbackAsync();
            throw;
        }



    }

}