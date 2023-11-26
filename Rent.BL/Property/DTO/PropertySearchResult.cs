namespace Rent.BL.Property.DTO;

public class PropertySearchResult
{
    public List<Domain.Entities.Properties.Property> Properties { get; set; } = new List<Domain.Entities.Properties.Property>();
    public int Total { get; set; }
}