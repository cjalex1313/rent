namespace Rent.API.Models.Property.Apartment;

public class UpdateApartmentResponse : GetApartmentResponse
{
    public UpdateApartmentResponse(Domain.Entities.Properties.Apartment apartment) : base(apartment)
    {
        
    }
}