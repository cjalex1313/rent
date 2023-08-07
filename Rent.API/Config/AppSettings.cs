namespace Rent.API.Config;

public class AppSettings
{
    public AdminConfig AdminConfig { get; set; } = null!;
}

public class AdminConfig
{
    public string Password { get; set; } = "";
    public string Email { get; set; } = "";
}