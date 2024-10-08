using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace cinema.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    [HttpPost("Register")]
    public IActionResult Register(RegisterRequest request)
    {
        return Ok();
    }
    [HttpPost("Login")]
    public IActionResult Login(LoginRequest request)
    {
        return Ok();
    }
}