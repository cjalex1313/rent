namespace Rent.Domain.Entities;

public class House : Property
{
    public double LandSize { get; set; }
    public int Levels { get; set; }
}