namespace Rent.API.Models.Base;

public class BaseResponse
{
    public bool Succeeded { get; set; } = true;
    public string? Error { get; set; } = null;
    public List<string>? Errors { get; set; } = null;
}