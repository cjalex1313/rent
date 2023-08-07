namespace Rent.Domain.Exceptions;

public class BaseException : Exception
{
    public int StatusCode { get; set; }
    public string ErrorMessage { get; set; } = "";

    public BaseException() : base()
    {
        StatusCode = 500;
        ErrorMessage = "Internal server error";
    }

    public BaseException(string errorMessage) : base(errorMessage)
    {
        StatusCode = 500;
        ErrorMessage = errorMessage;
    }
}