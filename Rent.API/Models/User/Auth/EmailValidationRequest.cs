using Rent.API.Models.Base;

namespace Rent.API.Models.User.Auth;

public class EmailValidationRequest : BaseRequest
{
    public Guid UserId { get; set; }
    public string Token { get; set; } = string.Empty;
}