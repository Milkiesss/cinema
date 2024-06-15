using cinema.Application.DTOs.Auditorium.Request;
using cinema.Application.DTOs.Auditorium.Responce;
using cinema.Application.DTOs.Movie.Request;
using cinema.Application.DTOs.Movie.Responce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.Interfaces.Services
{
    public interface IAuditoriumService
    {
        Task<AuditoriumCreateResponce> Create(AuditoriumCreateRequest entity);
        Task<AuditoriumUpdateResponce> Update(AuditoriumUpdateRequest entity);
        Task<bool> Delete(Guid id);
        Task<AuditoriumGetByIdResponce> GetById(Guid id);
        Task<ICollection<AuditoriumGetAllResponce>> GetAll();
    }
}
