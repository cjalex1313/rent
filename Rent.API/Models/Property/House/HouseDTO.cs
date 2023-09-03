namespace Rent.API.Models.Property.House;

public class HouseDTO : PropertyDTO
{
    public double LandSize { get; set; }
    public int Levels { get; set; }
}