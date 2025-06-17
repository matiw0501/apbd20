using System.ComponentModel.DataAnnotations;

namespace apbdKolos2ProbnyTest.DTOs;

public class ListDTO
{
    [Required]
    public List<IntsDTO> Ints { get; set; }
}

public class IntsDTO
{
    public int ItemId { get; set; }
    public int Amount { get; set; }
}