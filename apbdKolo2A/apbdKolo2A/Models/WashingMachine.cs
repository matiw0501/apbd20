using System.ComponentModel.DataAnnotations;

namespace apbdKolo2A.Models;

public class WashingMachine
{
    [Key]
    public int WashingMachineId { get; set; }
    public double MaxWeight { get; set; }
    [MaxLength(100)]
    public string SerialNumber { get; set; }
    
    public ICollection<AvailableProgram> AvailablePrograms { get; set; } = null!;
}