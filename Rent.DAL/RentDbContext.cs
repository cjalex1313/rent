using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rent.Domain.Entities.Properties;
using Rent.Domain.Entities.User;

namespace Rent.DAL;

public class RentDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Property> Properties { get; set; }
    public DbSet<Apartment> Apartments { get; set; }
    public DbSet<House> Houses { get; set; }
    public DbSet<UserDetail> UserDetails { get; set; }
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
        builder.Entity<Property>().HasOne(p => p.ThumnailImage).WithOne().HasForeignKey<Property>(p => p.ThumnailImageId);

        builder.Entity<Apartment>().ToTable("Apartments");

        builder.Entity<House>().ToTable("Houses");

        builder.Entity<UserDetail>().ToTable("UserDetails").HasKey(e => e.UserId);
        builder.Entity<UserDetail>().Property(c => c.FirstName).HasMaxLength(70);
        builder.Entity<UserDetail>().Property(c => c.LastName).HasMaxLength(40);
        builder.Entity<UserDetail>().Property(c => c.AvatarExtension).HasMaxLength(10);

        builder.Entity<PropertyImage>().ToTable("PropertyImages");
        builder.Entity<PropertyImage>().HasKey(p => p.Id);
        builder.Entity<PropertyImage>().Property(p => p.Extension).HasMaxLength(10);
        builder.Entity<PropertyImage>().HasOne(p => p.Property).WithMany(p => p.Images).HasForeignKey(p => p.PropertyId);
    }
}