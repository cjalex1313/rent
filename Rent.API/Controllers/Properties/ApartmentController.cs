using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rent.API.Models.Property;
using Rent.API.Models.Property.Apartment;
using Rent.BL.Property.Apartment;
using Rent.Domain.Exceptions.Properties.Apartments;

namespace Rent.API.Controllers.Properties;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ApartmentController : BaseController
{
    private readonly IApartmentService _apartmentService;

    public ApartmentController(IApartmentService apartmentService)
    {
        _apartmentService = apartmentService;
    }

    [HttpGet("{id:int}")]
    public ActionResult<GetApartmentResponse> GetApartment([FromRoute] int id)
    {
        var apartment = _apartmentService.GetApartment(id);
        var userId = GetUserId();
        if (userId != apartment.OwnerId)
        {
            var userName = GetUsername();
            throw new UserDoesNotHaveAccessToApartment(userName, id);
        }

        var response = new GetApartmentResponse(apartment);
        return Ok(response);
    }

    [HttpPost]
    public ActionResult<AddPropertyResponse> AddApartment([FromBody] AddApartmentRequest request)
    {
        var userId = GetUserId();
        var apartment = AddApartmentRequest.GetEntity(request, userId);
        int id = _apartmentService.AddAppartment(apartment);
        var response = new AddPropertyResponse(id);
        return Ok(response);
    }
}