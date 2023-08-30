using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rent.API.Models.Property;
using Rent.BL.Property.House;

namespace Rent.API.Controllers.Properties;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class HouseController : BaseController
{
    private readonly IHouseService _houseService;

    public HouseController(IHouseService houseService)
    {
        _houseService = houseService;
    }
    
    [HttpPost]
    public ActionResult<AddPropertyResponse> AddProperty([FromBody] AddHouseRequest request)
    {
        var userId = GetUserId();
        var house = AddHouseRequest.GetEntity(request, userId);
        int id = _houseService.AddHouse(house);
        var response = new AddPropertyResponse(id);
        return Ok(response);
    }
}