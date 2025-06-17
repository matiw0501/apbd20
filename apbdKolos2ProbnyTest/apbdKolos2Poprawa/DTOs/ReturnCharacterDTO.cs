namespace apbdKolos2ProbnyTest.DTOs;

public class ReturnCharacterDTO
{
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    public List<ItemDTO> ItemDtos { get; set; }
    public List<TitileDTO> TitileDtos { get; set; }
}

public class ItemDTO
{
    public String ItemName { get; set; }
    public int ItemWeight { get; set; }
    public int Amount { get; set; }
}

public class TitileDTO
{
    public string Titile { get; set; }
    public DateTime AquiredAt { get; set; }
}