namespace Rent.Domain.Exceptions.Properties.Houses;

public class UserDoesNotHaveAccessToHouse : BaseException
{
    public UserDoesNotHaveAccessToHouse(string username, int houseId)
    {
        this.StatusCode = 403;
        this.ErrorMessage = $"The user {username} does not have access to the house with id: {houseId}";
    }
}