using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tutorial5.Models;

[Table("PrescriptionMedicament")]
public class PrescriptionMedicament
{  
    [ForeignKey("Prescription")]
    public int IdPrescription { get; set; }
    
    public Prescription Prescription { get; set; }
    
    [ForeignKey("Medicament")]
    public int IdMedicament { get; set; }
    
    public Medicament Medicament { get; set; }
    
    public int? Dose { get; set; }
    
    [MaxLength(100)]
    public string Details { get; set; }
    
}