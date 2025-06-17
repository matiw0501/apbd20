using System.ComponentModel.DataAnnotations;

namespace apbdKolos2ProbnyTest.Models;

public class Title
{
    [Key]
    public int TitileId { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    
    public ICollection<CharacterTitle> CharacterTitles { get; set; }
}