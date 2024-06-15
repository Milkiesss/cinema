using cinema.Application.DTOs.Auditorium.Request;
using cinema.Application.DTOs.Movie.Request;
using cinema.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace cinema.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriumController : ControllerBase
    {
        private readonly IAuditoriumService _serv;
        public AuditoriumController(IAuditoriumService serv)
        {
            _serv = serv;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] AuditoriumCreateRequest request)
        {
            var result = await _serv.Create(request);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] AuditoriumUpdateRequest request)
        {
            var result = await _serv.Update(request);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var result = await _serv.GetById(Id);
            return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _serv.GetAll();
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
