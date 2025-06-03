
using Microsoft.EntityFrameworkCore;
using Tutorial11.Data;
using Tutorial11.DTOs;
using Tutorial11.Models;

namespace Tutorial11.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<List<BookWithAuthorsDto>> GetBooks()
    {
        var books = await _context.Books.Select(e =>
        new BookWithAuthorsDto {
            Name = e.Name,
            Price = e.Price,
            Authors = e.BookAuthors.Select(a =>
            new AuthorDto {
                FirstName = a.Author.FirstName,
                LastName = a.Author.LastName
            }).ToList()
        }).ToListAsync();
        return books;
    }

    public async Task <int?> AddPrescription(PrescriptionMedicament prescription)
    {
        return 1;
    }

    public async Task <int?> AddPrescriptionMedicament(PrescriptionMedicamentDTO prescriptionMedicamentDto)
    {
        if (prescriptionMedicamentDto.Medicaments.Count > 10 || prescriptionMedicamentDto.Medicaments.Count < 1)
            throw new InvalidDataException("bad amount of Medicaments. Must be beetwen 1 and 10");
        if(prescriptionMedicamentDto.DueDate.Date < prescriptionMedicamentDto.Date.Date)
            throw new InvalidDataException("due date cannot be further than date");
        
        foreach (var medicament in prescriptionMedicamentDto.Medicaments)
        {
            if (!_context.Medicaments.Any(m=> m.IdMedicament == medicament.IdMedicament))
            {
                throw new InvalidDataException("There is no such medicament " + medicament.IdMedicament);
            }
        }

        var patient = await _context.Patients.FirstOrDefaultAsync(p => p.IdPatient == prescriptionMedicamentDto.Patient.IdPatient );
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            if (patient == null)
            {
                patient = new Patient
                {
                    FirstName = prescriptionMedicamentDto.Patient.FirstName,
                    LastName = prescriptionMedicamentDto.Patient.LastName,
                    BirthDate = prescriptionMedicamentDto.Patient.BirthDate,
                };
                await _context.Patients.AddAsync(patient);
                await _context.SaveChangesAsync();
            }
            //tworzenie prescription


            var prescription = new Prescription()
            {
                IdPatient = patient.IdPatient,
                IdDoctor = prescriptionMedicamentDto.IdDoctor,
                PrescriptionMedicaments = new List<PrescriptionMedicament>(),
                Date = prescriptionMedicamentDto.Date,
                DueDate = prescriptionMedicamentDto.DueDate
            };
            foreach (var medicament in prescriptionMedicamentDto.Medicaments)
            {
                prescription.PrescriptionMedicaments.Add(new PrescriptionMedicament
                {
                    IdMedicament = medicament.IdMedicament,
                    Dose = medicament.Dose ?? 0,
                    Details = medicament.Description
                });
            }

            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();
            return prescription.IdPrescription;
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}