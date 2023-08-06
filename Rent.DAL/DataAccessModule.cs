using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Rent.DAL;

public static class DataAccessModule
{
    public static void AddDataAccessModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RentDbContext>(
            options => options.UseNpgsql(configuration.GetConnectionString("Rent"))
            );
    }
}