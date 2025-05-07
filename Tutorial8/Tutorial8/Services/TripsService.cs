using Microsoft.Data.SqlClient;
using Tutorial8.Models.DTOs;

namespace Tutorial8.Services;

public class TripsService : ITripsService
{
    private readonly string _connectionString =
        "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=APBD;Integrated Security=True;";

    public async Task<List<TripDTO>> GetTrips()
    {
        var trips = new List<TripDTO>();

        string command =
            "SELECT Trip.IdTrip as IdTrip, Trip.Name, Description, DateFrom, DateTo, MaxPeople, Country.Name as CountryName FROM Trip left join Country_Trip on Country_Trip.IdTrip = Trip.IdTrip left join Country on Country.IdCountry = Country_Trip.IdCountry";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        using (SqlCommand cmd = new SqlCommand(command, conn))
        {
            await conn.OpenAsync();

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    int id = reader.GetInt32(0);
                    var tripExist = trips.FirstOrDefault(x => x.Id == id);
                    if (tripExist == null)
                    {
                        tripExist = new TripDTO()
                        {
                            Id = id,
                            Name = reader.GetString(1),
                            Description = reader.GetString(2),
                            StartDate = reader.GetDateTime(3),
                            EndDate = reader.GetDateTime(4),
                            MaxPeople = reader.GetInt32(5),
                            Countries = new List<CountryDTO>()
                        };
                        trips.Add(tripExist);
                    }

                    if (!reader.IsDBNull(6))
                    {
                        var CountryName = reader.GetString(6);

                        tripExist.Countries.Add(new CountryDTO() { Name = CountryName });
                    }

                }
            }
        }


        return trips;
    }

    public async Task<List<ClientTripDTO>> GetTrip(int id)
    {
       var trips = new List<ClientTripDTO>();
       
       string checkClientQuery = "SELECT COUNT(1) FROM Client WHERE IdClient = @id";
       
       string command = 
           "SELECT  Client.IdClient, Client_Trip.IdTrip, Trip.Name, Trip.Description, Trip.DateFrom, Trip.DateTo, Trip.MaxPeople, Client_Trip.RegisteredAt, Client_Trip.PaymentDate FROM Client left join Client_Trip on Client_Trip.IdClient = Client.IdClient left join Trip on Client_Trip.IdTrip = Trip.IdTrip WHERE Client_Trip.IdClient = @id";
       bool clientExists = false;
       using(var conn = new SqlConnection(_connectionString))
       using (SqlCommand cmd = new SqlCommand(command, conn))
       {
           cmd.Parameters.AddWithValue("@id", id);
           await conn.OpenAsync();
           
           using (var checkCmd = new SqlCommand(checkClientQuery, conn))
           {
               checkCmd.Parameters.AddWithValue("@id", id);
               var exists = (int)await checkCmd.ExecuteScalarAsync();
               if (exists == 0)
               {
                   return null; // klient nie istnieje
               }
           }
           
           

           using (var reader = await cmd.ExecuteReaderAsync())
           {
               while (await reader.ReadAsync())
               {
                   clientExists = true;
                   if (reader.IsDBNull(1)) continue;
                   trips.Add(new ClientTripDTO()
                   {
                        TripId = reader.GetInt32(1),
                        Name = reader.GetString(2),
                        Description = reader.GetString(3),
                        StartDate = reader.GetDateTime(4),
                        EndDate = reader.GetDateTime(5),
                        MaxPeople = reader.GetInt32(6),
                        RegisteredAt = reader.GetInt32(7),
                        PaymentDate = reader.IsDBNull(8) ? null : reader.GetInt32(8)
                   });
               }   
           }
       }
       
       return trips;
       
    }

    public async Task<int?> AddClient(NewClientDTO client)
    {

        if (string.IsNullOrEmpty(client.FirstName) || string.IsNullOrEmpty(client.LastName)
                                                   || string.IsNullOrEmpty(client.Email) ||
                                                   string.IsNullOrEmpty(client.Phone)
                                                   || string.IsNullOrEmpty(client.Pesel))
        {
            throw new InvalidClientDataException();
        }
        string checkPeselQuery = "SELECT 1 FROM Client WHERE Pesel = @Pesel";
        string insertCommand =
            "INSERT INTO Client (FirstName, LastName, Email, Telephone, Pesel) OUTPUT INSERTED.IdClient VALUES (@FirstName, @LastName, @Email, @Telephone, @Pesel)";

        using (var conn = new SqlConnection(_connectionString))
        {
            await conn.OpenAsync();

            using (var checkCmd = new SqlCommand(checkPeselQuery, conn))
            {
                checkCmd.Parameters.AddWithValue("@Pesel", client.Pesel);
                var exists = await checkCmd.ExecuteScalarAsync();
                if (exists is not null)
                {
                    throw new ClientAlreadyExistsException(client.Pesel);
                }

                using (var insertCmd = new SqlCommand(insertCommand, conn))
                {
                    insertCmd.Parameters.AddWithValue("@FirstName", client.FirstName);
                    insertCmd.Parameters.AddWithValue("@LastName", client.LastName);
                    insertCmd.Parameters.AddWithValue("@Email", client.Email);
                    insertCmd.Parameters.AddWithValue("@Telephone", client.Phone);
                    insertCmd.Parameters.AddWithValue("@Pesel", client.Pesel);
                    var result = await insertCmd.ExecuteScalarAsync();
                    return Convert.ToInt32(result);
                }
            }
        }

    }



}

public class ClientAlreadyExistsException : Exception
{
    public ClientAlreadyExistsException(string pesel)
        : base($"Klient z PESEL {pesel} już istnieje.") {}
}

public class InvalidClientDataException : Exception
{
    public InvalidClientDataException() : base("Wszystkie pola są wymagane.") {}
}