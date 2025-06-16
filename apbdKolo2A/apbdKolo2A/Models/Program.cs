using System.ComponentModel.DataAnnotations;

namespace apbdKolo2A.Models;

public class Program
{
    [Key]
    public int ProgramId { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    public int DurationMinutes { get; set; }
    public int TemperatureCelsius { get; set; }


    public ICollection<AvailableProgram> AvailablePrograms { get; set; } = null!;
}