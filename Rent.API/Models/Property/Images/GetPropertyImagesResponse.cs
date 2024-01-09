using Rent.API.Models.Base;

namespace Rent.API.Models.Property.Images
{
    public class GetPropertyImagesResponse : BaseResponse
    {
        public List<PropertyImageDTO> Images { get; set; }
        public GetPropertyImagesResponse(List<PropertyImageDTO> images)
        {
            Images = images;
        }
    }
}
