using System.ComponentModel.DataAnnotations;

namespace Rent.API.Models.Property.Apartment;

public class AddApartmentRequest : AddPropertyRequest
{
    [Required]
    public int Floor { get; set; }
    [Required]
    public int BuildingMaxFloor { get; set; }
    [Required]
    public int ApartmentNumber { get; set; }

    public static Domain.Entities.Properties.Apartment GetEntity(AddApartmentRequest request, Guid ownerId)
    {
        var apt = new Domain.Entities.Properties.Apartment()
        {
            OwnerId = ownerId,
            Name = request.Name,
            Country = request.Country,
            City = request.City,
            State = request.State,
            Street = request.Street,
            PostalCode = request.PostalCode,
            Size = request.Size,
            Number = request.Number,
            Floor = request.Floor,
            BuildingMaxFloor = request.BuildingMaxFloor,
            ApartmentNumber = request.ApartmentNumber
        };
        return apt;
    }
}