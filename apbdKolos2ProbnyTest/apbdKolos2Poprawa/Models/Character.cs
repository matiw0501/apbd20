using System.ComponentModel.DataAnnotations;

namespace apbdKolos2ProbnyTest.Models;

public class Character
{
    [Key]
    public int CharacterId { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(120)]
    public string LastName { get; set; }
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    
    public ICollection<Backpack> Backpacks { get; set; }
    public ICollection<CharacterTitle> CharacterTitles { get; set; }
    
}