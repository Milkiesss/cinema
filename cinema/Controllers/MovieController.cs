using cinema.Application.DTOs.Movie.Request;
using cinema.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace cinema.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _serv;
        public MovieController(IMovieService serv)
        {
            _serv = serv;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] MovieCreateRequest request)
        {
            var result = await _serv.CreateAsync(request);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] MovieUpdateRequest request)
        {
            var result = await _serv.UpdateAsync(request);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(Guid Id)
        {
            var result = await _serv.GetByIdAsync(Id);
            return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _serv.GetAllAsync();
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var result = await _serv.DeleteAsync(Id);
            return Ok(result);
        }
    }
}
