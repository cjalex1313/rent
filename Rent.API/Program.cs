using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Rent.API.Middleware;
using Rent.BL;
using Rent.BL.Auth;
using Rent.DAL;
using Rent.Domain.Config;
using Rent.Domain.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var appSettings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>();
if (appSettings == null)
{
    throw new Exception("Unable to parse appSettings");
}

Console.WriteLine(builder.Configuration.GetConnectionString("Rent"));
Console.WriteLine(JsonSerializer.Serialize(appSettings));

builder.Services.AddCors();
builder.Services.AddSingleton(appSettings);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
});

builder.Services.AddBusinessLogicModule(builder.Configuration);
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<RentDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }
).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = true;
    var jwtSecret = builder.Configuration["JWT:Secret"];
    if (jwtSecret == null)
    {
        throw new BaseException("Invalid JWT Configuration");
    }
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = false,
        //ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();



app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var rentDbContext = scope.ServiceProvider.GetService<RentDbContext>();
    if (rentDbContext == null)
    {
        throw new BaseException("Cannot initialize DbContext");
    }
    rentDbContext.Database.Migrate();
    var adminRole = rentDbContext.Roles.FirstOrDefault(r => r.Name == "Admin");
    if (adminRole == null)
    {
        rentDbContext.Roles.Add(new IdentityRole()
        {
            Name = "Admin",
            NormalizedName = "ADMIN",
            ConcurrencyStamp = "1"
        });
    }
    var userRole = rentDbContext.Roles.FirstOrDefault(r => r.Name == "User");
    if (userRole == null)
    {
        rentDbContext.Roles.Add(new IdentityRole()
        {
            Name = "User",
            NormalizedName = "USER",
            ConcurrencyStamp = "2"
        });
    }
    rentDbContext.SaveChanges();
}

using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    scope.ServiceProvider.GetService<IAuthService>()
        ?.RegisterAdmin(appSettings.AdminConfig.Password, appSettings.AdminConfig.Email).Wait();
}

app.Run();