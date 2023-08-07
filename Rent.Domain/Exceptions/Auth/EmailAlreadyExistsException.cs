namespace Rent.Domain.Exceptions.Auth;

public class EmailAlreadyExistsException : BaseException
{
    public EmailAlreadyExistsException(string email)
    {
        this.StatusCode = 403;
        this.ErrorMessage = $"An user with the email: {email} already exists";
    }
}

public class UsernameAlreadyExistsException : BaseException
{
    public UsernameAlreadyExistsException(string username)
    {
        this.StatusCode = 403;
        this.ErrorMessage = $"An user with the username: {username} already exists";
    }
}