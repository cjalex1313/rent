using Rent.API.Models.Base;

namespace Rent.API.Models.Auth;

public class LoginResponse : BaseResponse
{
    public string Token { get; set; } = "";
    public DateTime ValidTo { get; set; }
}