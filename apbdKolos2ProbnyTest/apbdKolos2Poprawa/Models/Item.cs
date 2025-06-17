using System.ComponentModel.DataAnnotations;

namespace apbdKolos2ProbnyTest.Models;

public class Item
{
    [Key]
    public int ItemId { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    public int Weight { get; set; }
    
    public ICollection<Backpack> Backpacks { get; set; }
}