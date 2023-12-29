using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rent.API.Models.Base;
using Rent.API.Models.Property;
using Rent.API.Models.Property.Images;
using Rent.API.Models.Property.Search;
using Rent.BL.Property;
using Rent.Domain.Entities;
using Rent.Domain.Exceptions.Properties;

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

    [HttpGet("search")]
    public ActionResult<SearchPropertiesResponse> Search([FromQuery] SearchPropertiesRequest request)
    {
        var searchResult = _propertyService.Search(request.ToFilters());
        var result = new SearchPropertiesResponse(searchResult.Properties, searchResult.Total);
        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<BaseResponse> DeleteProperty([FromRoute] int id)
    {
        var userId = GetUserId();
        _propertyService.DeleteProperty(id, userId);
        return Ok(new BaseResponse());
    }

    [HttpGet("{id:int}/images")]
    public ActionResult<GetPropertyImagesResponse> GetPropertyImages([FromRoute] int id)
    {
        var propertyImages = _propertyService.GetPropertyImages(id);
        var list = new List<PropertyImageDTO>();
        foreach (var propertyImage in propertyImages)
        {
            var propertyImageDto = new PropertyImageDTO()
            {
                Id = propertyImage.Id,
                Url = _propertyService.GetPropertyImageUrl(propertyImage)
            };
            list.Add(propertyImageDto);
        }
        var response = new GetPropertyImagesResponse(list);
        return Ok(response);
    }

    [HttpPost("{id:int}/add-images")]
    public ActionResult<BaseResponse> AddPropertyImages([FromRoute] int id, [FromForm] List<IFormFile> images)
    {
        var userId = GetUserId();
        var property = _propertyService.GetProperty(id);
        if (property.OwnerId != userId)
        {
            var userName = GetUsername();
            throw new UserDoesNotHaveAccessToProperty(userName, id);
        }
        foreach (var image in images)
        {
            var fileName = image.FileName;
            var extension = Path.GetExtension(fileName);
            var isExtensionImage = extension == ".jpg" || extension == ".png" || extension == ".jpeg";
            if (!isExtensionImage)
            {
                return BadRequest("File extension is not supported");
            }
        }
        foreach (var image in images)
        {
            var fileName = image.FileName;
            var extension = Path.GetExtension(fileName);
            _propertyService.AddPropertyImage(id, extension, image.OpenReadStream());
        }
        return Ok(new BaseResponse());
    }

    [HttpPatch("{id:int}/set-thumbnail")]
    public ActionResult<BaseResponse> SetThumbnail([FromRoute] int id, [FromBody] SetThumbnailRequest request)
    {
        var userId = GetUserId();
        var property = _propertyService.GetProperty(id);
        if (property.OwnerId != userId)
        {
            var userName = GetUsername();
            throw new UserDoesNotHaveAccessToProperty(userName, id);
        }
        _propertyService.SetThumbnail(id, request.ImageId);
        return Ok(new BaseResponse());
    }
}