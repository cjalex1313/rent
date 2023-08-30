using Microsoft.EntityFrameworkCore;
using Rent.DAL;
using Rent.Domain.Entities;

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
}