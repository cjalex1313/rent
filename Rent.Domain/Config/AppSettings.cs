using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Domain.Config
{
    public class AppSettings
    {
        public AdminConfig AdminConfig { get; set; } = null!;
        public string EmailConfirmationUrl { get; set; } = string.Empty;
    }

    public class AdminConfig
    {
        public string Password { get; set; } = "";
        public string Email { get; set; } = "";
    }
}
