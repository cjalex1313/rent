using Rent.BL.Property.DTO;

namespace Rent.BL.Property;

public interface IPropertyService
{
    IEnumerable<Domain.Entities.Properties.Property> GetUserProperties(Guid userId);
    void DeleteProperty(int propertyId, Guid userId);
    PropertySearchResult Search(SearchPropertiesFilters toFilters);
    Domain.Entities.Properties.Property GetProperty(int id);
}