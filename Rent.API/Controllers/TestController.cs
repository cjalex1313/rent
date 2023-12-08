using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rent.BS.File;
using Rent.Email;
using Rent.Email.Models;

namespace Rent.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IFileService _fileService;

        public TestController(IEmailService emailService, IFileService fileService)
        {
            _emailService = emailService;
            _fileService = fileService;
        }

        [HttpPost("SendEmail")]
        public IActionResult SendEmail([FromBody] MailData mailData)
        {
#if DEBUG
            if (mailData == null)
            {
                return BadRequest();
            }
            _emailService.SendEmail(mailData, MimeKit.Text.TextFormat.Html);
#endif
            return Ok();
        }

        [HttpPost("TestFile")]
        [AllowAnonymous]
        public IActionResult TestFile([FromForm] IFormFile file)
        {
#if DEBUG
            _fileService.UploadTestFile(file.FileName, file.OpenReadStream());
#endif
            return Ok();
        }

        [HttpGet("TestGetFile")]
        [AllowAnonymous]
        public IActionResult TestGetFile([FromQuery] string key)
        {
            string cdn;
#if DEBUG
            cdn = _fileService.GetCDN(key);
#endif
            return Ok(cdn);
        }
    }
}
