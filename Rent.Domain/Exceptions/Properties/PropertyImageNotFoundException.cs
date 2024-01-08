namespace Rent.Domain.Exceptions.Properties;

public class PropertyImageNotFoundException : BaseException
{
  public PropertyImageNotFoundException(Guid imageId)
  {
    this.StatusCode = 404;
    this.ErrorMessage = $"Property image with id {imageId} was not found";
  }
}
