using Tutorial8.Models.DTOs;

namespace Tutorial8.Services;

public interface ITripsService
{
    Task<List<TripDTO>> GetTrips();
    Task<List<ClientTripDTO>> GetTrip(int id);
    Task<int?> AddClient(NewClientDTO client);
    Task RegisterClientOnTrip(int clientId, int tripId);
    Task DeleteRegistration(int clientId, int tripId);
}