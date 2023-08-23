using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rent.API.Models.Property;
using Rent.BL.Property;

namespace Rent.API.Controllers;

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
    
    [HttpPost("apartment")]
    public ActionResult<AddPropertyResponse> AddApartment([FromBody] AddApartmentRequest request)
    {
        var userId = GetUserId();
        var apartment = AddApartmentRequest.GetEntity(request, userId);
        int id = _propertyService.AddAppartment(apartment);
        var response = new AddPropertyResponse(id);
        return Ok(response);
    }

    [HttpPost("house")]
    public ActionResult<AddPropertyResponse> AddProperty([FromBody] AddHouseRequest request)
    {
        var userId = GetUserId();
        var house = AddHouseRequest.GetEntity(request, userId);
        int id = _propertyService.AddHouse(house);
        var response = new AddPropertyResponse(id);
        return Ok(response);
    }
}