using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Rent.DAL;

public class RentDbContext : IdentityDbContext<IdentityUser>
{
    public RentDbContext(DbContextOptions<RentDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        SeedRoles(builder);
    }

    private static void SeedRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityRole>().HasData(new List<IdentityRole>()
        {
            new IdentityRole() { Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "1"},
            new IdentityRole() { Name = "User", NormalizedName = "USER", ConcurrencyStamp = "2"}
        });
    }
}