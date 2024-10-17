using cinema.Application.DTOs.User;
using cinema.Application.Interfaces.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace cinema.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _serv;

    public UserController(IUserService serv)
    {
        _serv = serv;
    }

    [HttpPost("Reg")]
    public async Task<IActionResult> Registration(RegisterationRequest request)
    {
        var result = await _serv.Register(request);
        return Ok(result);
    }

}