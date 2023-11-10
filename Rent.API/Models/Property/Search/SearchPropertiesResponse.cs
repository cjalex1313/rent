using Rent.API.Models.Base;

namespace Rent.API.Models.Property.Search;

public class SearchPropertiesResponse : BaseResponse
{
    public SearchPropertiesResponse(IEnumerable<Domain.Entities.Property> properties)
    {
        Properties = properties.Select(p => new UserPropertyModel(p));
    }

    public IEnumerable<UserPropertyModel> Properties { get; set; }
}