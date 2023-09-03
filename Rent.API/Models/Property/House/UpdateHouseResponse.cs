namespace Rent.API.Models.Property.House;

public class UpdateHouseResponse : GetHouseResponse
{
    public UpdateHouseResponse(Domain.Entities.House house) : base(house)
    {
        
    }
}