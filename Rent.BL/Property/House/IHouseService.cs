namespace Rent.BL.Property.House;

public interface IHouseService 
{
    int AddHouse(Domain.Entities.Properties.House house);
    Domain.Entities.Properties.House GetHouse(int id);
    void UpdateHouse(Guid userId, Domain.Entities.Properties.House house);
}