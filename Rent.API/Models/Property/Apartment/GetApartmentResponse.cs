using Rent.API.Models.Base;

namespace Rent.API.Models.Property.Apartment;

public class GetApartmentResponse : BaseResponse
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
    public int Floor { get; set; }
    public int BuildingMaxFloor { get; set; }
    public int ApartmentNumber { get; set; }
    public GetApartmentResponse(Domain.Entities.Apartment apartment)
    {
        Id = apartment.Id;
        OwnerId = apartment.OwnerId;
        Name = apartment.Name;
        Country = apartment.Country;
        City = apartment.City;
        State = apartment.State;
        Street = apartment.Street;
        Number = apartment.Number;
        PostalCode = apartment.PostalCode;
        Size = apartment.Size;
        Floor = apartment.Floor;
        BuildingMaxFloor = apartment.BuildingMaxFloor;
        ApartmentNumber = apartment.ApartmentNumber;
    }
}