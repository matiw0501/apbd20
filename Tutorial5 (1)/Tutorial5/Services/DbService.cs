using Microsoft.EntityFrameworkCore;
using Tutorial5.Data;
using Tutorial5.DTOs;
using Tutorial5.Models;

namespace Tutorial5.Services;

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
    
    public async Task <int?> AddPrescriptionMedicament(PrescriptionMedicamentDTO prescriptionMedicamentDto)
    {
        if (prescriptionMedicamentDto.Medicaments.Count > 10 || prescriptionMedicamentDto.Medicaments.Count < 1)
            return null;
        if(prescriptionMedicamentDto.DueDate.Date < prescriptionMedicamentDto.Date.Date)
            return null;
        
        foreach (var medicament in prescriptionMedicamentDto.Medicaments)
        {
            if (!_context.Medicaments.Any(m=> m.IdMedicament == medicament.IdMedicament))
            {
                return null;
            }
        }

        var patient = _context.Patients.FirstOrDefault(p => p.IdPatient == prescriptionMedicamentDto.Patient.IdPatient && p.FirstName == prescriptionMedicamentDto.Patient.FirstName
                                                            && p.LastName == prescriptionMedicamentDto.Patient.LastName
                                                            && p.BirthDate.Date == prescriptionMedicamentDto.Patient.BirthDate.Date);
        if (patient == null)
        {
            patient = new Patient
            {
                FirstName = prescriptionMedicamentDto.Patient.FirstName,
                LastName = prescriptionMedicamentDto.Patient.LastName,
                BirthDate = prescriptionMedicamentDto.Patient.BirthDate,
            };
            _context.Patients.Add(patient);
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
                Dose = medicament.Dose?? 0,
                Details = medicament.Description
            });
        }

        _context.Prescriptions.Add(prescription);
        await _context.SaveChangesAsync();
        return prescription.IdPrescription;
    }
}