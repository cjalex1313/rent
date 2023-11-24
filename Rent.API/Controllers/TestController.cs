using Microsoft.AspNetCore.Mvc;
using Rent.Email;
using Rent.Email.Models;

namespace Rent.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public TestController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("SendEmail")]
        public IActionResult SendEmail([FromBody] MailData mailData)
        {
            if (mailData == null)
            {
                return BadRequest();
            }
            _emailService.SendEmail(mailData, MimeKit.Text.TextFormat.Html);
            return Ok();
        }
    }
}
