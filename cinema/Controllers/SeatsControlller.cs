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
            var result = await _serv.CreateRangeAsync(request);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateRange([FromBody] ICollection<SeatsUpdateRequest> request)
        {
            var result = await _serv.UpdateRangeAsync(request);
            return Ok(result);
        }
        [HttpDelete("DeleteRow")]
        public async Task<IActionResult> DeleteRow(int RowNumber)
        {
            var result = await _serv.DeleteRowAsync(RowNumber);
            return Ok(result);
        }
    }
}
