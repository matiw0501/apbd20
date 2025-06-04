using System.ComponentModel.DataAnnotations;

namespace kolos2.Models;

public class Ticket
{
    [Key]
    public int Id { get; set; }
    public string Serial { get; set; } = Guid.NewGuid().ToString();
    public int SeatNumber { get; set; }

    public int ConcertId { get; set; }
    public Concert Concert { get; set; } = null!;
}