using apbdKolo2A.Models;

namespace apbdKolo2A.DTOs;

public class ClientOrdersDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public List<PurchaseDTO> Purchases { get; set; }
}

public class PurchaseDTO
{
    public DateTime Date { get; set; }
    public int? Rating { get; set; }
    public double Price { get; set; }
    public WashingMachineDTO WashingMachine { get; set; }
    public ProgramDTO Program { get; set; }
    
}

public class WashingMachineDTO
{
    public string SerialNumber { get; set; }
    public double MaxWeight { get; set; }
}

public class ProgramDTO
{
    public string Name { get; set; }
    public int Duration { get; set; }
}