namespace Rent.Domain.Exceptions;

public class BaseException : Exception
{
    public int StatusCode { get; set; }
    public string ErrorMessage { get; set; } = "";
    public List<string> Errors { get; set; }

    public BaseException() : base()
    {
        StatusCode = 500;
        ErrorMessage = "Internal server error";
        Errors = new List<string>();
    }

    public BaseException(string errorMessage) : base(errorMessage)
    {
        StatusCode = 500;
        ErrorMessage = errorMessage;
        Errors = new List<string>();
    }
}