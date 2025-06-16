using System.ComponentModel.DataAnnotations;
using apbdKolo2A.Models;

namespace apbdKolo2A.DTOs;

public class AddWashingMachineDTO
{
    public WashingMDTO WashingMachine { get; set; }
    public List<AvailableProgramDTO> AvailablePrograms { get; set; }
}


public class WashingMDTO
{
    [Required]
    [Range(8, int.MaxValue)]
    public double MaxWeight { get; set; }
    [Required]
    public string SerialNumber { get; set; }
}

public class AvailableProgramDTO
{
    [Required]
    public string ProgramName { get; set; }
    [Required]
    [Range(0, 25)]
    public double price { get; set; }
}