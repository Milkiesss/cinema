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
        public async Task<IActionResult> Create([FromBody] CommentCreateRequest request)
        {
            var result = await _serv.Create(request);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] CommentUpdateRequest request)
        {
            var result = await _serv.Update(request);
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
