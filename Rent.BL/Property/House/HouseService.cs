using Rent.DAL;

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
}