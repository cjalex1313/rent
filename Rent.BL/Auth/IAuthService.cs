using System.IdentityModel.Tokens.Jwt;

namespace Rent.BL.Auth;

public interface IAuthService
{
    Task RegisterUser(string username, string email, string password);
    Task RegisterAdmin(string adminPassword, string adminEmail);
    Task<JwtSecurityToken> Login(string username, string password);
}