namespace Rent.API.Models.Property.House;

public class UpdateHouseResponse : GetHouseResponse
{
    public UpdateHouseResponse(Domain.Entities.Properties.House house) : base(house)
    {
        
    }
}