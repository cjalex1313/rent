using Microsoft.AspNetCore.Mvc;
using Rent.API.Models.Auth;
using Rent.BL.Auth;

namespace Rent.API.Controllers;

[Microsoft.AspNetCore.Components.Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthenticationController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
    {
        await _authService.RegisterUser(request.Username, request.Email, request.Password);
        return Ok();
    }
}