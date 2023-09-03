namespace Rent.API.Models.Property.Apartment;

public class ApartmentDTO : PropertyDTO
{
    public int Floor { get; set; }
    public int BuildingMaxFloor { get; set; }
    public int ApartmentNumber { get; set; }
}