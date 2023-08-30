using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rent.API.Models.Property;
using Rent.BL.Property;

namespace Rent.API.Controllers.Properties;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class PropertyController : BaseController
{
    private readonly IPropertyService _propertyService;

    public PropertyController(IPropertyService propertyService)
    {
        _propertyService = propertyService;
    }

    [HttpGet]
    public ActionResult<GetUserPropertiesResponse> GetUserProperties()
    {
        var userId = GetUserId();
        var userProperties = _propertyService.GetUserProperties(userId);
        var response = new GetUserPropertiesResponse(userProperties);
        return Ok(response);
    }
}