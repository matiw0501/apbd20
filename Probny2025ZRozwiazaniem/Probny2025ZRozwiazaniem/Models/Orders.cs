using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Probny2025ZRozwiazaniem.Models;

public class Orders
{
    [Key]
    public int OrderId { get; set; }
    [Required]
    public DateTime OrderedAt { get; set; }
    public DateTime? FulfilledAt { get; set; }
    
    [ForeignKey(nameof(Client))]
    public int ClientId { get; set; }
    public Client Client { get; set; }


    [ForeignKey(nameof(Status))]
    public int StatusId { get; set; }
    public Status Status { get; set; }
}