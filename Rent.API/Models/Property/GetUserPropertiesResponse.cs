using Rent.API.Models.Base;

namespace Rent.API.Models.Property;

public class GetUserPropertiesResponse : BaseResponse
{
    public IEnumerable<UserPropertyModel> Properties { get; set; }
    public GetUserPropertiesResponse(IEnumerable<Domain.Entities.Properties.Property> userProperties)
    {
        Properties = userProperties.Select(up =>
        {
            return new UserPropertyModel(up);
        }).ToList();
    }
}

public enum PropertyTypeEnum
{
    Unknown = 0,
    Apartment = 1,
    House = 2
}

public class UserPropertyModel
{
    public int Id { get; set; }
    public Guid OwnerId { get; set; }
    public string Name { get; set; } = "";
    public string Country { get; set; } = "";
    public string City { get; set; } = "";
    public string? State { get; set; }
    public string Street { get; set; } = "";
    public string Number { get; set; } = "";
    public string PostalCode { get; set; } = "";
    public double Size { get; set; }
    public PropertyTypeEnum PropertyType { get; set; }

    public UserPropertyModel(Domain.Entities.Properties.Property property)
    {
        Id = property.Id;
        OwnerId = property.OwnerId;
        Name = property.Name;
        Country = property.Country;
        City = property.City;
        State = property.State;
        Street = property.Street;
        Number = property.Number;
        PostalCode = property.PostalCode;
        Size = property.Size;
        switch (property)
        {
            case Domain.Entities.Properties.Apartment:
                PropertyType = PropertyTypeEnum.Apartment;
                break;
            case Domain.Entities.Properties.House:
                PropertyType = PropertyTypeEnum.House;
                break;
            default:
                PropertyType = PropertyTypeEnum.Unknown;
                break;
        }
    }
}