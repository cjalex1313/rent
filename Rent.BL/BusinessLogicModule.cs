﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rent.BL.Auth;
using Rent.BL.Property;
using Rent.BL.Property.Apartment;
using Rent.BL.Property.House;
using Rent.BS.File;
using Rent.BS.UserDetails;
using Rent.DAL;
using Rent.Email;
using Rent.FileManager;

namespace Rent.BL;

public static class BusinessLogicModule
{
    public static void AddBusinessLogicModule(this IServiceCollection services,
        ConfigurationManager builderConfiguration)
    {
        services.AddDataAccessModule(builderConfiguration);
        services.AddEmailModule(builderConfiguration);
        services.AddFileManagerModule(builderConfiguration);
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IPropertyService, PropertyService>();
        services.AddScoped<IApartmentService, ApartmentService>();
        services.AddScoped<IHouseService, HouseService>();
        services.AddScoped<IUserDetailsService, UserDetailsService>();
        services.AddScoped<IFileService,  FileService>();
    }
}