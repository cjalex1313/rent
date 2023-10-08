using Microsoft.EntityFrameworkCore;
using Rent.DAL;
using Rent.Domain.Entities;
using Rent.Domain.Exceptions.Properties;

namespace Rent.BL.Property;

public class PropertyService : IPropertyService
{
    private readonly RentDbContext _context;

    public PropertyService(RentDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Domain.Entities.Property> GetUserProperties(Guid userId)
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
}