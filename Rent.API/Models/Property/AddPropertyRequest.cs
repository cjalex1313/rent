using Rent.API.Models.Base;

namespace Rent.API.Models.Property;

public class AddPropertyRequest : BaseRequest
{
    public string Name { get; set; } = "";
    public string Country { get; set; } = "";
    public string City { get; set; } = "";
    public string Street { get; set; } = "";
}