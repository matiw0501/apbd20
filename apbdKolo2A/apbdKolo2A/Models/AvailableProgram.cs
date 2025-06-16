using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apbdKolo2A.Models;

public class AvailableProgram
{
    [Key]
    public int AvailableProgramId { get; set; }
    [ForeignKey(nameof(WashingMachine))]
    public int WashingMachineId { get; set; }
    [ForeignKey(nameof(Program))]
    public int ProgramId { get; set; }
    [Precision(10,2)]
    public double Price { get; set; }
    
    
    
    public WashingMachine WashingMachine { get; set; } = null!;
    public Program Program { get; set; } = null!;
    
    
    public ICollection<PurchaseHistory> PurchaseHistories { get; set; } = null!;
}