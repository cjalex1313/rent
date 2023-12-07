using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Rent.FileManager
{
    public static class FileManagerModule
    {
        public static void AddFileManagerModule(this IServiceCollection services, ConfigurationManager configuration)
        {
            var s3Config = configuration.GetSection("S3Config").Get<S3Config>();
            if (s3Config == null)
            {
                throw new Exception("Error - incorrect s3 config - unable to map s3 config");
            }
            services.AddSingleton(s3Config);
            services.AddScoped<IFileManager, FileManager>();
        }
    }
}
