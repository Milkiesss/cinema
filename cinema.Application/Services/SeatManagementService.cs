using cinema.Application.DTOs.Seats.Request;
using cinema.Application.Interfaces.Repository;
using cinema.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.Services
{
    public class SeatManagementService : ISeatManagementService
    {
        private readonly IAuditoriumRepository _Auditrep;

        public SeatManagementService(IAuditoriumRepository Auditrep)
        {
            _Auditrep = Auditrep;
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
        public async Task<bool> CountCapacity(Guid Id)
        {
            var auditory = await  _Auditrep.GetById(Id);
            if (auditory is null)
                return false;
            var seatCount = auditory.Seats.Count();
            auditory.Capacity = seatCount;
            await _Auditrep.Update(auditory);
            return true;
        }
    }
}
