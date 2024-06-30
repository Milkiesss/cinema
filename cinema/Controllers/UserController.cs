using cinema.Application.DTOs.User.Request;
using cinema.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace cinema.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _serv;
        public UserController(IUserService serv)
        {
            _serv = serv;
        }
        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromBody] UserCreateRequest request)
        {
            var result = await _serv.Create(request);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UserUpdateRequest request)
        {
            var result = await _serv.Update(request);
            return Ok(result);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            var responce = await _serv.Login(request);
            return Ok(responce);
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