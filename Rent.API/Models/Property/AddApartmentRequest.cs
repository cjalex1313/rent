using Rent.Domain.Entities;

namespace Rent.API.Models.Property;

public class AddApartmentRequest : AddPropertyRequest
{
    public int Floor { get; set; }
    public int BuildingMaxFloor { get; set; }
    public int ApartmentNumber { get; set; }

    public static Apartment GetEntity(AddApartmentRequest request, Guid ownerId)
    {
        var apt = new Apartment()
        {
            OwnerId = ownerId,
            Name = request.Name,
            Country = request.Country,
            City = request.City,
            State = request.State,
            Street = request.Street,
            PostalCode = request.PostalCode,
            Size = request.Size,
            Floor = request.Floor,
            BuildingMaxFloor = request.BuildingMaxFloor,
            ApartmentNumber = request.ApartmentNumber
        };
        return apt;
    }
}