using Rent.Domain.Entities;

namespace Rent.BL.Property;

public interface IPropertyService
{
    int AddAppartment(Apartment apartment);
    int AddHouse(House house);
    IEnumerable<Domain.Entities.Property> GetAllProperties();
}