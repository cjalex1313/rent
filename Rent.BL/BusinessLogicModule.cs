using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rent.BL.Auth;
using Rent.DAL;

namespace Rent.BL;

public static class BusinessLogicModule
{
    public static void AddBusinessLogicModule(this IServiceCollection services,
        IConfiguration builderConfiguration)
    {
        services.AddDataAccessModule(builderConfiguration);
        services.AddTransient<IAuthService, AuthService>();
    }
}