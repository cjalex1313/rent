using System;
using System.Collections.Generic;
using System.Text;

namespace Rent.Email.Models
{
    public class MailData
    {
        public string Email { get; set; } = "";
        public string Name { get; set; } = "";
        public string Subject { get; set; } = "";
        public string Body { get; set; } = "";
    }
}
