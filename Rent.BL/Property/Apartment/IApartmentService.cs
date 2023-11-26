namespace Rent.BL.Property.Apartment;

public interface IApartmentService
{
    int AddAppartment(Domain.Entities.Properties.Apartment apartment);
    Domain.Entities.Properties.Apartment GetApartmentDTO(int id);
    void UpdateApartment(Guid userId, Domain.Entities.Properties.Apartment newApartment);
}