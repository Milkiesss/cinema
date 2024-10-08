using cinema.Application.DTOs.Auditorium.Request;
using cinema.Application.DTOs.Auditorium.Responce;

namespace cinema.Application.Interfaces.Services
{
    public interface IAuditoriumService
    {
        Task<AuditoriumCreateResponce> CreateAsync(AuditoriumCreateRequest entity);
        Task<AuditoriumUpdateResponce> UpdateAsync(AuditoriumUpdateRequest entity);
        Task<bool> DeleteAsync(Guid id);
        Task<AuditoriumGetByIdResponce> GetByIdAsync(Guid id);
        Task<ICollection<AuditoriumGetAllResponce>> GetAllAsync();
    }
}
