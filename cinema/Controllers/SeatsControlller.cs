using cinema.Application.DTOs.Seats.Request;
using cinema.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace cinema.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly ISeatsService _serv;
        public SeatsController(ISeatsService serv)
        {
            _serv = serv;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] SeatsCreateRequest request)
        {
            var result = await _serv.CreateRange(request);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateRange([FromBody] ICollection<SeatsUpdateRequest> request)
        {
            var result = await _serv.UpdateRange(request);
            return Ok(result);
        }
        [HttpDelete("DeleteRow")]
        public async Task<IActionResult> DeleteRow(int RowNumber)
        {
            var result = await _serv.DeleteRow(RowNumber);
            return Ok(result);
        }
        [HttpGet("GetSeatsByAuditoriumId")]
        public async Task<IActionResult> GetSeatsByAuditoriumId(Guid Id)
        {
            var result = await _serv.GetSeatsByAuditoriumId(Id);
            return Ok(result);
        }
    }
}
