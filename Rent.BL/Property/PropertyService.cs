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

    public int AddAppartment(Apartment apartment)
    {
        _context.Apartments.Add(apartment);
        _context.SaveChanges();
        return apartment.Id;
    }

    public int AddHouse(House house)
    {
        _context.Houses.Add(house);
        _context.SaveChanges();
        return house.Id;
    }

    public IEnumerable<Domain.Entities.Property> GetUserProperties(Guid userId)
    {
        var properties = _context.Properties.Where(p => p.OwnerId == userId).ToList();
        return properties;
    }
}