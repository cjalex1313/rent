namespace Rent.BL.Property.DTO;

public class SearchPropertiesFilters
{
    public string Country { get; set; } = "";
    public string? City { get; set; }
    public string? State { get; set; }
    public int Page { get; set; } = 0;
    public int PageSize { get; set; } = 20;
}