using cinema.Application.DTOs.Movie.Request;
using cinema.Application.DTOs.Screening.Request;
using cinema.Application.Interfaces.Services;
using cinema.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace cinema.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreeningController : ControllerBase
    {
        private readonly IScreeningService _serv;
        public ScreeningController(IScreeningService serv)
        {
            _serv = serv;
        } 
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ICollection<ScreeningCreateRequest> request)
        {
            var result = await _serv.CreateRange(request);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] ScreeningUpdateRequest request)
        {
            var result = await _serv.Update(request);
            return Ok(result);
        }
        [HttpGet("GetByDateAndAuditoriumId")]
        public async Task<IActionResult> GetById(/*[FromQuery] ScreeningGetByDateAndAuditoriumIdRequest request*/ DateTime date, Guid Id )
        {
            var result = await _serv.GetDailyScreeningsByAuditoriumId(DateTime date, Guid Id);
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
