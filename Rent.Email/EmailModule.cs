using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Rent.Email
{
    public static class EmailModule
    {
        public static void AddEmailModule(this IServiceCollection services,
        ConfigurationManager builderConfiguration)
        {
            var emailConfig = builderConfiguration.GetSection("EmailConfig").Get<EmailConfig>();
            if (emailConfig == null)
            {
                throw new Exception("Error - incorrect email config - unable to map email config");
            }
            services.AddSingleton<EmailConfig>(emailConfig);
        }
    }
}
