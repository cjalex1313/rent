using System.ComponentModel.DataAnnotations;

namespace Rent.API.Models.Property.House;

public class UpdateHouseRequest : UpdatePropertyRequest
{
    [Required]
    public double LandSize { get; set; }
    [Required]
    public int Levels { get; set; }

    public Domain.Entities.House GetHouse()
    {
        var house = new Domain.Entities.House()
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
            LandSize = LandSize,
            Levels = Levels
        };
        return house;
    }
}