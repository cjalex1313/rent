using Rent.DAL;

namespace Rent.BL.Property.Apartment;

public class ApartmentService : PropertyService, IApartmentService
{
    private readonly RentDbContext _context;

    public ApartmentService(RentDbContext context) : base(context)
    {
        _context = context;
    }
    
    public int AddAppartment(Domain.Entities.Apartment apartment)
    {
        _context.Apartments.Add(apartment);
        _context.SaveChanges();
        return apartment.Id;
    }
}