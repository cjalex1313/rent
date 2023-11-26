using Rent.API.Models.Base;

namespace Rent.API.Models.Property.House;

public class GetHouseResponse : BaseResponse
{
    public HouseDTO House { get; set; }

    public GetHouseResponse(Domain.Entities.Properties.House house)
    {
        this.House = new HouseDTO()
        {
            Id = house.Id,
            OwnerId = house.OwnerId,
            Name = house.Name,
            Country = house.Country,
            City = house.City,
            State = house.State,
            Street = house.Street,
            Number = house.Number,
            PostalCode = house.PostalCode,
            Size = house.Size,
            LandSize = house.LandSize,
            Levels = house.Levels
        };
    }
}