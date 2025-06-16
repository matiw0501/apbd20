using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Probny2025ZRozwiazaniem.Models;

[PrimaryKey(nameof(ProductId), nameof(OrderId))]
public class ProductsOrdered
{
   
    [ForeignKey(nameof(Product))]
    public int ProductId { get; set; }
    
    
    [ForeignKey(nameof(Orders))]
    public int OrderId { get; set; }
    
    public int Amount { get; set; }
    
    
    public Product Product { get; set; } = null!;
    
    public Orders Orders { get; set; } = null!;
}