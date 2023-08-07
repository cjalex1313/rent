namespace Rent.Domain.Exceptions.Auth;

public class UserCreationException : BaseException
{
    public UserCreationException(List<string> errors)
    {
        this.Errors = errors;
        StatusCode = 409;
        ErrorMessage = "Error while trying to create the user";
    }
}