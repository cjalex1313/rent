using Microsoft.EntityFrameworkCore;
using Rent.DAL;
using Rent.Domain.Exceptions.Properties;
using Rent.Domain.Exceptions.Properties.Houses;

namespace Rent.BL.Property.House;

public class HouseService : IHouseService
{
    private readonly RentDbContext _context;

    public HouseService(RentDbContext context)
    {
        _context = context;
    }
    
    public int AddHouse(Domain.Entities.House house)
    {
        _context.Houses.Add(house);
        _context.SaveChanges();
        return house.Id;
    }

    public Domain.Entities.House GetHouse(int id)
    {
        var house = _context.Houses.AsNoTracking().FirstOrDefault(h => h.Id == id);
        if (house == null)
        {
            throw new HouseNotFoundException(id);
        }

        return house;
    }

    public void UpdateHouse(Guid userId, Domain.Entities.House house)
    {
        var dbHouse = _context.Houses.FirstOrDefault(h => h.Id == house.Id);
        if (dbHouse == null)
        {
            throw new HouseNotFoundException(house.Id);
        }

        if (userId != dbHouse.OwnerId)
        {
            throw new UserNotOwnerOfPropertyException(dbHouse.Id);
        }
        _context.Entry(dbHouse).CurrentValues.SetValues(house);
        _context.SaveChanges();
    }
}