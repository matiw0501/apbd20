using Tutorial5.Models;

namespace Tutorial5.DTOs;

public class PrescriptionMedicamentDTO
{
    public PatientDto Patient { get; set; }
    public int IdDoctor { get; set; }
    public List<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}


public class PatientDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}

public class MedicamentsDto
{
    public string IdMedicament { get; set; }
    public int? Dose { get; set; }
    public string Description { get; set; }
}