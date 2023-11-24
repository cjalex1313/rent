using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Rent.API.Models.Auth;
using Rent.API.Models.Base;
using Rent.BL.Auth;
using Rent.Domain.Exceptions;

namespace Rent.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : BaseController
{
    private readonly IAuthService _authService;

    public AuthenticationController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Register")]
    public async Task<ActionResult<BaseResponse>> Register([FromBody] RegisterUserRequest request)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Where(m => m.Value != null).SelectMany(m => m.Value!.Errors).ToList();
            throw new ModelValidationException(errors.Select(e => e.ErrorMessage).ToList());
        }
        await _authService.RegisterUser(request.Username, request.Email, request.Password);
        return Ok(new BaseResponse());
    }

    [HttpPost("Confirmation")]
    public async Task<IActionResult> EmailConfirmation([FromBody] EmailValidationRequest request)
    {
        await _authService.ConfirmEmail(request.UserId, request.Token);
        return Ok(new BaseResponse());
    }

    [HttpPost("Login")]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Where(m => m.Value != null).SelectMany(m => m.Value!.Errors).ToList();
            throw new ModelValidationException(errors.Select(e => e.ErrorMessage).ToList());
        }
        var token = await _authService.Login(request.Username, request.Password);
        var response = new LoginResponse()
        {
            Succeeded = true,
            Errors = null,
            Error = null,
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            ValidTo = token.ValidTo
        };
        return Ok(response);
    }
}