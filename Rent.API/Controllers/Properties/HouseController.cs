using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rent.API.Models.Property;
using Rent.API.Models.Property.House;
using Rent.BL.Property.House;
using Rent.Domain.Exceptions.Properties;
using Rent.Domain.Exceptions.Properties.Houses;

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

    [HttpGet("{id:int}")]
    public ActionResult<GetHouseResponse> GetHouse([FromRoute] int id)
    {
        var house = _houseService.GetHouse(id);
        var userId = GetUserId();
        if (userId != house.OwnerId)
        {
            var userName = GetUsername();
            throw new UserDoesNotHaveAccessToHouse(userName, id);
        }

        var response = new GetHouseResponse(house);
        return Ok(response);
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

    [HttpPut]
    public ActionResult<UpdateHouseResponse> UpdateHouse([FromBody] UpdateHouseRequest request)
    {
        var userId = GetUserId();
        if (userId != request.OwnerId)
        {
            throw new UserNotAllowedToTransferPropertyException();
        }

        var house = request.GetHouse();
        _houseService.UpdateHouse(userId, house);
        var response = new UpdateHouseResponse(house);
        return Ok(response);
    }
}