using Rent.BL.Property.DTO;
using Rent.Domain.Entities;

namespace Rent.BL.Property;

public interface IPropertyService
{
    IEnumerable<Domain.Entities.Property> GetUserProperties(Guid userId);
    void DeleteProperty(int propertyId, Guid userId);
    List<Domain.Entities.Property> Search(SearchPropertiesFilters toFilters);
}