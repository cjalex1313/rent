namespace Rent.BL.Property.Apartment;

public interface IApartmentService
{
    int AddAppartment(Domain.Entities.Apartment apartment);
    Domain.Entities.Apartment GetApartment(int id);
}