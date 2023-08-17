namespace Rent.Domain.Entities;

public class Property
{
    public int Id { get; set; }
    public Guid OwnerId { get; set; }
    public string Name { get; set; } = "";
    public string Country { get; set; } = "";
    public string City { get; set; } = "";
    public string? State { get; set; }
    public string Street { get; set; } = "";
    public int Number { get; set; }
    public string PostalCode { get; set; } = "";
    public double Size { get; set; }
}