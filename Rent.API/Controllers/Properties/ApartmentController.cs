using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rent.API.Models.Property;
using Rent.BL.Property.Apartment;

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