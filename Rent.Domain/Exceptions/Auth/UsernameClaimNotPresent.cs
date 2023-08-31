namespace Rent.Domain.Exceptions.Auth;

public class UsernameClaimNotPresent : BaseException
{
    public UsernameClaimNotPresent(string userId)
    {
        this.StatusCode = 500;
        this.ErrorMessage = $"User with id {userId} does not have username claim present in the jwt";
    }
}