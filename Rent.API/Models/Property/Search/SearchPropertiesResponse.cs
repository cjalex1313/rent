using Rent.API.Models.Base;

namespace Rent.API.Models.Property.Search;

public class SearchPropertiesResponse : BaseResponse
{
    public SearchPropertiesResponse(IEnumerable<Domain.Entities.Property> properties, int total)
    {
        Properties = properties.Select(p => new UserPropertyModel(p));
        Total = total;
    }

    public IEnumerable<UserPropertyModel> Properties { get; set; }
    public int Total { get; set; }
}