using Tutorial5.DTOs;
using Tutorial5.Models;

namespace Tutorial5.Services;

public interface IDbService
{
    Task<List<BookWithAuthorsDto>> GetBooks();
    Task <PrescriptionMedicamentDTO> AddPrescriptionMedicament(PrescriptionMedicamentDTO prescriptionMedicamentDto);
    
}