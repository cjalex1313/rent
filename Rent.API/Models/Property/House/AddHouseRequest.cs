using System.ComponentModel.DataAnnotations;

namespace Rent.API.Models.Property.House;

public class AddHouseRequest : AddPropertyRequest
{
    [Required]
    public double LandSize { get; set; }
    [Required]
    public int Levels { get; set; }

    public static Domain.Entities.Properties.House GetEntity(AddHouseRequest request, Guid userId)
    {
        var house = new Domain.Entities.Properties.House()
        {
            OwnerId = userId,
            Name = request.Name,
            Country = request.Country,
            City = request.City,
            State = request.State,
            Street = request.Street,
            PostalCode = request.PostalCode,
            Size = request.Size,
            Number = request.Number,
            LandSize = request.LandSize,
            Levels = request.Levels
        };
        return house;
    }
}