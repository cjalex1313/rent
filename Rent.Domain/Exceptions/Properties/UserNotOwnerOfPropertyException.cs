using System.Runtime.CompilerServices;

namespace Rent.Domain.Exceptions.Properties;

public class UserNotOwnerOfPropertyException : BaseException
{
    public UserNotOwnerOfPropertyException(int propertyId)
    {
        this.StatusCode = 403;
        this.ErrorMessage = $"User is trying to access a property with it {propertyId} which it does not own";
    }
}