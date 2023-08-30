namespace Rent.BL.Property.Apartment;

public interface IApartmentService : IPropertyService
{
    int AddAppartment(Domain.Entities.Apartment apartment);
}