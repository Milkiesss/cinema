using cinema.Application.DTOs.Seats.Request;
using cinema.Application.Interfaces.Repository;
using cinema.Application.Interfaces.Services;

namespace cinema.Application.Services
{
    public class SeatManagementService : ISeatManagementService
    {
        private readonly IAuditoriumRepository _auditrep;

        public SeatManagementService(IAuditoriumRepository auditrep)
        {
            _auditrep = auditrep;
        }
        public ICollection<SeatsCreateRequest> FillSeats(SeatsCreateRequest seats)
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
        }
        public async Task<bool> CountCapacity(Guid id)
        {
            var auditory = await  _auditrep.GetById(id);
            if (auditory is null)
                return false;
            var seatCount = auditory.Seats.Count();
            auditory.Capacity = seatCount;
            await _auditrep.Update(auditory);
            return true;
        }
    }
}
