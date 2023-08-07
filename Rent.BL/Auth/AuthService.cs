using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Rent.Domain.Exceptions.Auth;

namespace Rent.BL.Auth;

public class AuthService : IAuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;

    public AuthService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
    }

    public async Task RegisterUser(string username, string email, string password)
    {
        // check user exists
        var emailExists  = await _userManager.FindByEmailAsync(email);
        if (emailExists != null)
        {
            throw new EmailAlreadyExistsException(email);
        }

        var usernameExists = await _userManager.FindByNameAsync(username);
        if (usernameExists != null)
        {
            throw new UsernameAlreadyExistsException(username);
        }
        // Add the user to the database

        // Assign a role
    }
}