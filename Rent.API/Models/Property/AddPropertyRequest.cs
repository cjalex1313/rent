using Rent.API.Models.Base;

namespace Rent.API.Models.Property;

public abstract class AddPropertyRequest : BaseRequest
{
    public string Name { get; set; } = "";
    public string Country { get; set; } = "";
    public string City { get; set; } = "";
    public string? State { get; set; }
    public string Street { get; set; } = "";
    public string PostalCode { get; set; } = "";
    public string Number { get; set; } = "";
    public double Size { get; set; }
}