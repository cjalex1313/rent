using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Rent.API.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class PropertyController : ControllerBase
{
    
}