using Rent.DAL;

namespace Rent.BL.Property;

public class PropertyService : IPropertyService
{
    private readonly RentDbContext _context;

    public PropertyService(RentDbContext context)
    {
        _context = context;
    }
}