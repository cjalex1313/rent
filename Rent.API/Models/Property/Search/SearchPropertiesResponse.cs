using Rent.API.Models.Base;

namespace Rent.API.Models.Property.Search;

public class SearchPropertiesResponse : BaseResponse
{
    public SearchPropertiesResponse(IEnumerable<UserPropertyModel> properties, int total)
    {
        Properties = properties;
        Total = total;
    }

    public IEnumerable<UserPropertyModel> Properties { get; set; }
    public int Total { get; set; }
}