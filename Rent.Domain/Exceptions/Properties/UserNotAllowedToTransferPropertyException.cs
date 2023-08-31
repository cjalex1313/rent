namespace Rent.Domain.Exceptions.Properties;

public class UserNotAllowedToTransferPropertyException : BaseException
{
    public UserNotAllowedToTransferPropertyException()
    {
        this.StatusCode = 403;
        this.ErrorMessage = "User is not allowed to change the owner of the property";
    }
}