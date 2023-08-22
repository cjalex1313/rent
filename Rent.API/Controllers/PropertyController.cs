using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rent.API.Models.Base;
using Rent.API.Models.Property;
using Rent.Domain.Exceptions.Auth;

namespace Rent.API.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class PropertyController : BaseController
{
    public PropertyController()
    {
        
    }
    
    [HttpPost("apartment")]
    public ActionResult<BaseResponse> AddApartment([FromBody] AddApartmentRequest request)
    {
        var userId = GetUserId();
        var apartment = AddApartmentRequest.GetEntity(request, userId);
        return Ok(new BaseResponse()
        {
            Succeeded = true
        });
    }
}