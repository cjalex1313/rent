namespace Rent.Domain.Exceptions.Properties;

public class UserDoesNotHaveAccessToProperty : BaseException
{
  public UserDoesNotHaveAccessToProperty(string username, int propertyId)
  {
    this.StatusCode = 403;
    this.ErrorMessage = $"The user {username} does not have access to the property with id: {propertyId}";
  }
}