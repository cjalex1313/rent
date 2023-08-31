namespace Rent.API.Models.Property.Apartment;

public class UpdateApartmentResponse : GetApartmentResponse
{
    public UpdateApartmentResponse(Domain.Entities.Apartment apartment) : base(apartment)
    {
        
    }
}