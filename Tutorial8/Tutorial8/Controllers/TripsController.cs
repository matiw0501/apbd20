using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial8.Models.DTOs;
using Tutorial8.Services;

namespace Tutorial8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ITripsService _tripsService;

        public TripsController(ITripsService tripsService)
        {
            _tripsService = tripsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrips()
        {
            var trips = await _tripsService.GetTrips();
            return Ok(trips);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrip(int id)
        {
           var trip = await _tripsService.GetTrip(id);
           if (trip == null)
               return NotFound();
           if(trip.Count == 0)
               return Ok(new {message = "Client exist but not registered any trips"});
           return Ok(trip);
        }
        
        [HttpPost("/api/clients")]
        public async Task<IActionResult> AddClient([FromBody] NewClientDTO client)
        {
            try
            {
                var id = await _tripsService.AddClient(client);
                return CreatedAtAction(nameof(GetTrip), new { id }, new { message = "Klient został dodany", id });
            }
            catch (InvalidClientDataException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (ClientAlreadyExistsException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }


        [HttpPut("/api/clients/{clientId}/trips/{tripId}")]
        public async Task<IActionResult> RegisterClientOnTrip(int clientId, int tripId)
        {
            try
            {
                await _tripsService.RegisterClientOnTrip(clientId, tripId);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpDelete("/api/clients/{clientId}/trips/{tripId}")]
        public async Task<IActionResult> DeleteClient(int clientId, int tripId)
        {
            try
            {
                await _tripsService.DeleteRegistration(clientId, tripId);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(new { message = e.Message });
            }
        }

    }
}
