namespace Rent.Domain.Entities.Properties;

public class PropertyImage
{
  public Guid Id { get; set; }
  public int PropertyId { get; set; }
  public string Extension { get; set; } = "";

  public virtual Property? Property { get; set; }
}