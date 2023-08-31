using System.ComponentModel.DataAnnotations;

namespace Rent.API.Models.Property.Apartment;

public class UpdateApartmentRequest : UpdatePropertyRequest
{
    [Required]
    public int Floor { get; set; }
    [Required]
    public int BuildingMaxFloor { get; set; }
    [Required]
    public int ApartmentNumber { get; set; }

    public Domain.Entities.Apartment GetApartment()
    {
        var apt = new Domain.Entities.Apartment()
        {
            Id = Id,
            OwnerId = OwnerId,
            Name = Name,
            Country = Country,
            City = City,
            State = State,
            Street = Street,
            PostalCode = PostalCode,
            Size = Size,
            Number = Number,
            Floor = Floor,
            BuildingMaxFloor = BuildingMaxFloor,
            ApartmentNumber = ApartmentNumber
        };
        return apt;
    }
}