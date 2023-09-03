namespace Rent.Domain.Exceptions.Properties.Houses;

public class HouseNotFoundException : BaseException
{
    public HouseNotFoundException(int houseId)
    {
        this.StatusCode = 404;
        this.ErrorMessage = $"The house with id {houseId} was not found in the database";
    }
}