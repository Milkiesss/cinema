using cinema.Application.DTOs.Auditorium.Request;
using cinema.Application.DTOs.Auditorium.Response;

namespace cinema.Application.Interfaces.Services
{
    public interface IAuditoriumService
    {
        Task<AuditoriumCreateResponse> CreateAsync(AuditoriumCreateRequest entity);
        Task<AuditoriumUpdateResponse> UpdateAsync(AuditoriumUpdateRequest entity);
        Task<bool> DeleteAsync(Guid id);
        Task<AuditoriumGetByIdResponse> GetByIdAsync(Guid id);
        Task<ICollection<AuditoriumGetAllResponse>> GetAllAsync();
    }
}
