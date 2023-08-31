namespace Rent.Domain.Exceptions.Properties.Apartments;

public class ApartmentNotFoundException : BaseException
{
    public ApartmentNotFoundException(int apartmentId)
    {
        this.StatusCode = 404;
        this.ErrorMessage = $"The apartment with id {apartmentId} was not found in the database";
    }
}