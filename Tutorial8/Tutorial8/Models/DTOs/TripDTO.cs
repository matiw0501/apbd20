namespace Tutorial8.Models.DTOs;

public class TripDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int MaxPeople { get; set; }
    public List<CountryDTO> Countries { get; set; }
}

public class CountryDTO
{
    public string Name { get; set; }
}

public class ClientTripDTO
{
    public int TripId { get; set; }   
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int MaxPeople { get; set; }
    public int RegisteredAt { get; set; }
    public int? PaymentDate {get; set;}
}

public class NewClientDTO()
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Pesel { get; set; }
}

