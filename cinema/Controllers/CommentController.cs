using cinema.Application.DTOs.Comment.Request;
using cinema.Application.DTOs.Movie.Request;
using cinema.Application.Interfaces.Services;
using cinema.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace cinema.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _serv;
        public CommentController(ICommentService serv)
        {
            _serv = serv;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] CommentCreateRequest request)
        {
            var result = await _serv.CreateAsync(request);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] CommentUpdateRequest request)
        {
            var result = await _serv.UpdateAsync(request);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
            var result = await _serv.DeleteAsync(Id);
            return Ok(result);
        }
    }
}
