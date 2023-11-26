using Microsoft.EntityFrameworkCore;
using Rent.BL.Property.DTO;
using Rent.DAL;
using Rent.Domain.Exceptions.Properties;

namespace Rent.BL.Property;

public class PropertyService : IPropertyService
{
    private readonly RentDbContext _context;

    public PropertyService(RentDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Domain.Entities.Properties.Property> GetUserProperties(Guid userId)
    {
        var properties = _context.Properties.Where(p => p.OwnerId == userId).ToList();
        return properties;
    }

    public void DeleteProperty(int propertyId, Guid userId)
    {
        var property = _context.Properties.FirstOrDefault(p => p.Id == propertyId);
        if (property == null)
        {
            throw new PropertyNotFoundException(propertyId);
        }

        if (property.OwnerId != userId)
        {
            throw new UserNotOwnerOfPropertyException(propertyId);
        }
        _context.Properties.Remove(property);
        _context.SaveChanges();
    }

    public PropertySearchResult Search(SearchPropertiesFilters filters)
    {
        var result = new PropertySearchResult();
        var propertiesQuery = _context.Properties.Where(p => p.Country.ToLower().Contains(filters.Country));
        if (filters.City != null)
        {
            propertiesQuery = propertiesQuery.Where(p => p.City.ToLower().Contains(filters.City));
        }
        if (filters.State != null)
        {
            propertiesQuery = propertiesQuery.Where(p => p.State != null && p.State.ToLower().Contains(filters.State));
        }

        result.Total = propertiesQuery.Count();
        var properties = propertiesQuery.OrderBy(p => p.Id).Skip(filters.PageSize * filters.Page).Take(filters.PageSize).ToList();
        result.Properties = properties;
        return result;
    }
}