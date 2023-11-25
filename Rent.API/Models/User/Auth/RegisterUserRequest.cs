using System.ComponentModel.DataAnnotations;
using Rent.API.Models.Base;

namespace Rent.API.Models.User.Auth;

public class RegisterUserRequest : BaseRequest
{
    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set; } = "";
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email address is not valid")]
    public string Email { get; set; } = "";
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = "";
}