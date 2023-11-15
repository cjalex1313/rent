namespace Rent.BL.Property.DTO;

public class PropertySearchResult
{
    public List<Domain.Entities.Property> Properties { get; set; } = new List<Domain.Entities.Property>();
    public int Total { get; set; }
}