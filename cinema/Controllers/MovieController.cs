using cinema.Application.DTOs.Movie.Pag;
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
        public async Task<IActionResult> Create([FromBody] MovieCreateRequest request)
        {
            var result = await _serv.Create(request);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] MovieUpdateRequest request)
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
        [HttpGet("GetPage")]
        public async Task<IActionResult> GetPagedMovies([FromQuery] MoviePagRequest request)
        {
            var result = await _serv.GetPagedMovies(request);
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
