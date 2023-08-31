namespace Rent.Domain.Exceptions.Properties.Apartments;

public class UserDoesNotHaveAccessToApartment : BaseException
{
    public UserDoesNotHaveAccessToApartment(string username, int apartmentId)
    {
        this.StatusCode = 403;
        this.ErrorMessage = $"The user {username} does not have access to the apartment with id: {apartmentId}";
    }
}