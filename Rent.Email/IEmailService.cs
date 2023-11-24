using MimeKit.Text;
using Rent.Email.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rent.Email
{
    public interface IEmailService
    {
        void SendEmail(MailData mailData, TextFormat textFormat = TextFormat.Plain);
    }
}
