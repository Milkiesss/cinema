using cinema.Application.DTOs.Seats.Request;
using cinema.Application.Interfaces.Repository;
using cinema.Application.Interfaces.Services;

namespace cinema.Application.Services
{
    public class SeatManagementService : ISeatManagementService
    {
        private readonly IAuditoriumRepository _auditoriumRepository;

        public SeatManagementService(IAuditoriumRepository auditoriumRepository)
        {
            _auditoriumRepository = auditoriumRepository;
        }
        public async Task<ICollection<SeatsCreateRequest>> FillSeatsAsync(SeatsCreateRequest seats)
        {
            return await Task.Run(() =>
            {
                var fill = Enumerable.Range(1, seats.SeatNumber)
                    .Select(seatNumber => new SeatsCreateRequest
                    {
                        AuditoriumId = seats.AuditoriumId,
                        RowNumber = seats.RowNumber,
                        SeatNumber = seatNumber,
                        PriceModifire = seats.PriceModifire
                    }).ToList();

                return fill;
            });
        }
        public async Task<bool> CountCapacityAsync(Guid id)
        {
            var auditory = await  _auditoriumRepository.GetByIdAsync(id);
            if (auditory is null)
                return false;
            var seatCount = auditory.Seats.Count();
            auditory.Capacity = seatCount;
            await _auditoriumRepository.UpdateAsync(auditory);
            return true;
        }
    }
}
