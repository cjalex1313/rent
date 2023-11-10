using Rent.BL.Property.DTO;

namespace Rent.API.Models.Property.Search;

public class SearchPropertiesRequest
{
    public string Country { get; set; } = "";
    public string? City { get; set; }
    public string? State { get; set; }
    public int Page { get; set; } = 0;
    public int PageSize { get; set; } = 20;

    public SearchPropertiesFilters ToFilters()
    {
        return new SearchPropertiesFilters()
        {
            Country = Country?.ToLower() ?? "",
            City = City?.ToLower(),
            State = State?.ToLower(),
            Page = Page,
            PageSize = PageSize
        };
    }
}