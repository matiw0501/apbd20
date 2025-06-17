using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apbdKolos2ProbnyTest.Models;

[PrimaryKey(nameof(CharacterdId), nameof(ItemId))]
public class Backpack
{
    [ForeignKey(nameof(Character))]
    public int CharacterdId { get; set; }
    [ForeignKey(nameof(Item))]
    public int ItemId { get; set; }
    public int Amount { get; set; }
    
    public Character Character { get; set; }
    public Item Item { get; set; }
    
    
}