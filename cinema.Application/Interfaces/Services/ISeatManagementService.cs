using cinema.Application.DTOs.Seats.Request;

namespace cinema.Application.Interfaces.Services;

public interface ISeatManagementService
{ 
    ICollection<SeatsCreateRequest> FillSeats(SeatsCreateRequest seats); 
    Task<bool> CountCapacity(Guid id);
}