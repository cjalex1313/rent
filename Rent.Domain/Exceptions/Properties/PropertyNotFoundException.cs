namespace Rent.Domain.Exceptions.Properties;

public class PropertyNotFoundException : BaseException
{
    public PropertyNotFoundException(int propertyId)
    {
        this.StatusCode = 404;
        this.ErrorMessage = $"Property with id {propertyId} was not found";
    }
}