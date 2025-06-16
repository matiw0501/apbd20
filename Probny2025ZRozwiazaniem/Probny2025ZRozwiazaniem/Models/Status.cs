using System.ComponentModel.DataAnnotations;

namespace Probny2025ZRozwiazaniem.Models;

public class Status
{
    [Key]
    public int StatusId { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    public ICollection<Orders> Orders { get; set; } = null!;
}