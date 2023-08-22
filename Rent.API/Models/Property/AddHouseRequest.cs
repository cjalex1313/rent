namespace Rent.API.Models.Property;

public class AddHouseRequest : AddPropertyRequest
{
    public double LandSize { get; set; }
    public int Levels { get; set; }
}