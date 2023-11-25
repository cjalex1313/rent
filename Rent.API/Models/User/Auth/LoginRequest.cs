using System.ComponentModel.DataAnnotations;
using Rent.API.Models.Base;

namespace Rent.API.Models.User.Auth;

public class LoginRequest : BaseRequest
{
    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set; } = "";
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = "";
}
