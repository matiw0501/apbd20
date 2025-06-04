using System.ComponentModel.DataAnnotations;

namespace kolos2.Models;

public class Concert
{
    [Key]
    public int Id { get; set; }
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }

    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}