using Rent.API.Models.Base;

namespace Rent.API.Models.Property.Apartment;

public class GetApartmentResponse : BaseResponse
{
    public ApartmentDTO Apartment { get; set; }
    public GetApartmentResponse(Domain.Entities.Apartment apartment)
    {
        this.Apartment = new ApartmentDTO()
        {
            Id = apartment.Id,
            OwnerId = apartment.OwnerId,
            Name = apartment.Name,
            Country = apartment.Country,
            City = apartment.City,
            State = apartment.State,
            Street = apartment.Street,
            Number = apartment.Number,
            PostalCode = apartment.PostalCode,
            Size = apartment.Size,
            Floor = apartment.Floor,
            BuildingMaxFloor = apartment.BuildingMaxFloor,
            ApartmentNumber = apartment.ApartmentNumber
        };
    }
}