using Microsoft.EntityFrameworkCore;
using Rent.DAL;
using Rent.Domain.Exceptions.Properties;
using Rent.Domain.Exceptions.Properties.Apartments;

namespace Rent.BL.Property.Apartment;

public class ApartmentService : IApartmentService
{
    private readonly RentDbContext _context;

    public ApartmentService(RentDbContext context)
    {
        _context = context;
    }
    
    public int AddAppartment(Domain.Entities.Apartment apartment)
    {
        _context.Apartments.Add(apartment);
        _context.SaveChanges();
        return apartment.Id;
    }

    public Domain.Entities.Apartment GetApartmentDTO(int id)
    {
        var apartment = _context.Apartments.AsNoTracking().FirstOrDefault(a => a.Id == id);
        if (apartment == null)
        {
            throw new ApartmentNotFoundException(id);
        }
        return apartment;
    }

    public void UpdateApartment(Guid userId, Domain.Entities.Apartment newApartment)
    {
        var dbApartment = _context.Apartments.FirstOrDefault(a => a.Id == newApartment.Id);
        if (dbApartment == null)
        {
            throw new ApartmentNotFoundException(newApartment.Id);
        }

        if (userId != dbApartment.OwnerId)
        {
            throw new UserNotOwnerOfPropertyException(dbApartment.Id);
        }
        
        _context.Entry(dbApartment).CurrentValues.SetValues(newApartment);
        _context.SaveChanges();
    }
}