using cinema.Application.DTOs.Reservation.Request;
using cinema.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace cinema.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _serv;
        public ReservationController(IReservationService serv)
        {
            _serv = serv;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ReservationCreateRequest request)
        {
            var result = await _serv.Create(request);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] ReservationUpdateRequest request)
        {
            var result = await _serv.Update(request);
            return Ok(result);
        }
        [HttpGet("GetByScreeningId")]
        public async Task<IActionResult> GetByScreeningId(Guid Id)
        {
            var result = await _serv.GetByScreeningId(Id);
            return Ok(result);
        }
        [HttpGet("GetByMovieId")]
        public async Task<IActionResult> GetByMovieId(Guid Id)
        {
            var result = await _serv.GetByMovieId(Id);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var result = await _serv.Delete(Id);
            return Ok(result);
        }
    }
}