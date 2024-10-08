using cinema.Application.DTOs.Seats.Request;

namespace cinema.Application.Interfaces.Services;

public interface ISeatManagementService
{ 
    Task<ICollection<SeatsCreateRequest>> FillSeatsAsync(SeatsCreateRequest seats); 
    Task<bool> CountCapacityAsync(Guid id);
}