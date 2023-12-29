using Rent.BL.Property.DTO;
using Rent.Domain.Entities.Properties;

namespace Rent.BL.Property;

public interface IPropertyService
{
    IEnumerable<Domain.Entities.Properties.Property> GetUserProperties(Guid userId);
    void DeleteProperty(int propertyId, Guid userId);
    PropertySearchResult Search(SearchPropertiesFilters toFilters);
    Domain.Entities.Properties.Property GetProperty(int id);
    void AddPropertyImage(int propertyId, string extension, Stream stream);
    IEnumerable<PropertyImage> GetPropertyImages(int propertyId);
    string GetPropertyImageUrl(PropertyImage propertyImage);
    void SetThumbnail(int propertyId, Guid imageId);
}