using System.ComponentModel.DataAnnotations;
using Rent.Domain.Entities;

namespace Rent.API.Models.Property;

public class AddHouseRequest : AddPropertyRequest
{
    [Required]
    public double LandSize { get; set; }
    [Required]
    public int Levels { get; set; }

    public static House GetEntity(AddHouseRequest request, Guid userId)
    {
        var house = new House()
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