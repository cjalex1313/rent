namespace Rent.Domain.Exceptions;

public class ModelValidationException : BaseException
{
    public ModelValidationException(List<string> errors)
    {
        this.StatusCode = 400;
        this.ErrorMessage = "Invalid data";
        this.Errors = errors;
    }
}