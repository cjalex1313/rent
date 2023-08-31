namespace Rent.BL.Property.Apartment;

public interface IApartmentService
{
    int AddAppartment(Domain.Entities.Apartment apartment);
    Domain.Entities.Apartment GetApartmentDTO(int id);
    void UpdateApartment(Guid userId, Domain.Entities.Apartment newApartment);
}