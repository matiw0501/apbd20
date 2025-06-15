using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Probny2025ZRozwiazaniem.Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    [Column(TypeName = "decimal")]
    [Precision(10,2)]
    public double Price { get; set; }
}