using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rent.API.Models.Base;
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

    [HttpDelete("{id:int}")]
    public ActionResult<BaseResponse> DeleteProperty([FromRoute] int id)
    {
        var userId = GetUserId();
        _propertyService.DeleteProperty(id, userId);
        return Ok(new BaseResponse());
    }
}