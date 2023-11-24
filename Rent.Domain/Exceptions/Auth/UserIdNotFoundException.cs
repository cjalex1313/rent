using System.Net;

namespace Rent.Domain.Exceptions.Auth;

public class UserIdNotFoundException : BaseException {
    public UserIdNotFoundException(Guid userId)
    {
        this.StatusCode = (int)HttpStatusCode.NotFound;
        this.ErrorMessage = $"No user with ID {userId} found";
    }
}