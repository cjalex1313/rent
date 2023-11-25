using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rent.Domain.Entities.Properties;

namespace Rent.DAL;

public class RentDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Property> Properties { get; set; }
    public DbSet<Apartment> Apartments { get; set; }
    public DbSet<House> Houses { get; set; }
    public RentDbContext(DbContextOptions<RentDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Property>().ToTable("Properties");
        builder.Entity<Property>().HasKey(p => p.Id);
        builder.Entity<Property>().Property(p => p.Name).HasMaxLength(200);
        builder.Entity<Property>().Property(p => p.Country).HasMaxLength(100);
        builder.Entity<Property>().Property(p => p.City).HasMaxLength(200);
        builder.Entity<Property>().Property(p => p.State).HasMaxLength(100);
        builder.Entity<Property>().Property(p => p.Street).HasMaxLength(200);
        builder.Entity<Property>().Property(p => p.Number).HasMaxLength(20);
        builder.Entity<Property>().Property(p => p.PostalCode).HasMaxLength(20);
        builder.Entity<Apartment>().ToTable("Apartments");
        builder.Entity<House>().ToTable("Houses");
    }
}