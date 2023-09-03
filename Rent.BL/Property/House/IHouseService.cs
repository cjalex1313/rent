namespace Rent.BL.Property.House;

public interface IHouseService 
{
    int AddHouse(Domain.Entities.House house);
    Domain.Entities.House GetHouse(int id);
    void UpdateHouse(Guid userId, Domain.Entities.House house);
}