namespace Rent.Domain.Entities.Properties;

public class Property
{
    public int Id { get; set; }
    public Guid OwnerId { get; set; }
    public string Name { get; set; } = "";
    public string Country { get; set; } = "";
    public string City { get; set; } = "";
    public string? State { get; set; }
    public string Street { get; set; } = "";
    public string Number { get; set; } = "";
    public string PostalCode { get; set; } = "";
    public double Size { get; set; }
    public Guid? ThumnailImageId { get; set; }

    public virtual IEnumerable<PropertyImage>? Images { get; set; }
    public virtual PropertyImage? ThumnailImage { get; set; }
}
