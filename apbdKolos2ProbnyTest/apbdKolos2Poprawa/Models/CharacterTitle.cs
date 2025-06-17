using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apbdKolos2ProbnyTest.Models;

[PrimaryKey(nameof(CharacterId), nameof(TitileId))]
public class CharacterTitle
{
    [ForeignKey(nameof(Character))]
    public int CharacterId { get; set; }
    [ForeignKey(nameof(Title))]
    public int TitileId { get; set; }
    public DateTime AcquiredAt { get; set; }
    
    public Character Character { get; set; }
    public Title Title { get; set; }
}