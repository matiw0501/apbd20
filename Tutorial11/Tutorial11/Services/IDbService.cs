using Tutorial11.DTOs;


namespace Tutorial11.Services;

public interface IDbService
{
    Task<List<BookWithAuthorsDto>> GetBooks();
   // Task<int?> AddPrescriptionMedicament(PrescriptionMedicamentDTO prescriptionMedicamentDto);
    
}