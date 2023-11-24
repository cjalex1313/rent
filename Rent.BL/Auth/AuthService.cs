using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Rent.Domain.Config;
using Rent.Domain.Exceptions;
using Rent.Domain.Exceptions.Auth;
using Rent.Email;

namespace Rent.BL.Auth;

public class AuthService : IAuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IEmailService _emailService;
    private readonly AppSettings _appSettings;

    public AuthService(UserManager<IdentityUser> userManager, IConfiguration configuration, IEmailService emailService, AppSettings appSettings)
    {
        _userManager = userManager;
        _configuration = configuration;
        _emailService = emailService;
        _appSettings = appSettings;
    }

    public async Task RegisterUser(string username, string email, string password)
    {
        await CheckIfUserExists(username, email);
        var identityUser = await AddUser(username, email, password);
        await AddRoleToUser(identityUser, "User");
    }
    
    public async Task RegisterAdmin(string adminPassword, string adminEmail)
    {
        var admin = await _userManager.FindByNameAsync("admin");
        if (admin == null)
        {
            var identityAdmin = await AddUser("admin", adminEmail, adminPassword);
            await AddRoleToUser(identityAdmin, "Admin");
        }
        else
        {
            admin.Email = adminEmail;
            admin.EmailConfirmed = true;
            await _userManager.UpdateAsync(admin);
            var token = await _userManager.GeneratePasswordResetTokenAsync(admin);
            var result = await _userManager.ResetPasswordAsync(admin, token, adminPassword);
            if (!result.Succeeded)
            {
                throw new Exception("Error while setting admin password");
            }

            var roles = await _userManager.GetRolesAsync(admin);
            if (!roles.Contains("Admin"))
            {
                await _userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }

    public async Task ConfirmEmail(Guid userId, string token)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user == null)
        {
            throw new UserIdNotFoundException(userId);
        }
        var result = await _userManager.ConfirmEmailAsync(user, token);
        if (result == null || !result.Succeeded)
        {
            throw new BaseException()
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                ErrorMessage = result != null ? String.Join(". ", result.Errors.Select(e => e.Description).ToList()) : "Error while confirming email via confirmation token"
            };
        }
    }

    public async Task<JwtSecurityToken> Login(string username, string password)
    {
        var user = await _userManager.FindByNameAsync(username);
        if (user == null)
        {
            throw new LoginUserNotFoundException(username);
        }
        var loginAttempt = await _userManager.CheckPasswordAsync(user, password);
        if (!loginAttempt)
        {
            throw new PasswordIncorrectException();
        }

        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        };
        var userRoles = await _userManager.GetRolesAsync(user);
        foreach (var role in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, role));
        }

        var token = GetToken(authClaims);
        return token;
    }

    private JwtSecurityToken GetToken(List<Claim> authClaims)
    {
        var jwtSecret = _configuration["JWT:Secret"];
        if (jwtSecret == null)
        {
            throw new BaseException("JWT configuration invalid");
        }
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            //audience:  _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddDays(7),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );
        return token;
    }

    private async Task AddRoleToUser(IdentityUser identityUser, string role)
    {
        var roleResult = await _userManager.AddToRoleAsync(identityUser, role);
        if (!roleResult.Succeeded)
        {
            throw new UserCreationException(roleResult.Errors.Select(e => e.Description).ToList());
        }
    }

    private async Task<IdentityUser> AddUser(string username, string email, string password)
    {
        var identityUser = new IdentityUser()
        {
            UserName = username,
            Email = email,
            SecurityStamp = Guid.NewGuid().ToString(),
        };
        var result = await _userManager.CreateAsync(identityUser, password);
        if (!result.Succeeded)
        {
            throw new UserCreationException(result.Errors.Select(e => e.Description).ToList());
        }
        var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);
        if (confirmationToken != null)
        {
            _emailService.SendEmail(new Email.Models.MailData
            {
                Email = email,
                Name = username,
                Subject = "Email confirmation",
                Body = $"Welcome to Rent. Click <a href=\"{_appSettings.EmailConfirmationUrl + "?userId=" + identityUser.Id + "&token=" + confirmationToken}\">here</a> to confirm your email"
            }, MimeKit.Text.TextFormat.Html);
        }
        return identityUser;
    }

    private async Task CheckIfUserExists(string username, string email)
    {
        var emailExists = await _userManager.FindByEmailAsync(email);
        if (emailExists != null)
        {
            throw new EmailAlreadyExistsException(email);
        }

        var usernameExists = await _userManager.FindByNameAsync(username);
        if (usernameExists != null)
        {
            throw new UsernameAlreadyExistsException(username);
        }
    }
}