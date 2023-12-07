using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Rent.API.Models.Base;
using Rent.API.Models.User.UserDetail;
using Rent.BS.UserDetails;
using Rent.Domain.Entities.User;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Rent.API.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserDetailController : BaseController
    {
        private readonly IUserDetailsService _userDetailsService;

        public UserDetailController(IUserDetailsService userDetailsService)
        {
            this._userDetailsService = userDetailsService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var userId = GetUserId();
            UserDetail? userDetail = _userDetailsService.GetUserDetail(userId);
            var response = new GetUserDetailResponse(userDetail, _userDetailsService);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Set([FromBody] SetUserDetailRequest request)
        {
            var userId = GetUserId();
            var userDetail = new UserDetail
            {
                UserId = userId,
                FirstName = request.FirstName,
                LastName = request.LastName
            };
            _userDetailsService.SetUserDetail(userDetail);
            var response = new GetUserDetailResponse(userDetail, _userDetailsService);
            return Ok(response);
        }

        [HttpPost("avatar")]
        public IActionResult SetUserAvatar([FromForm] IFormFile avatar)
        {
            var filename = avatar.FileName;
            var extension = Path.GetExtension(filename);
            var isExtensionImage = extension == ".jpg" || extension == ".png" || extension == ".jpeg";
            if (!isExtensionImage)
            {
                return BadRequest("File extension is not supported");
            }
            var userId = GetUserId();
            _userDetailsService.SetUserAvatar(userId, extension, avatar.OpenReadStream());
            UserDetail? userDetail = _userDetailsService.GetUserDetail(userId);
            var response = new GetUserDetailResponse(userDetail, _userDetailsService);
            return Ok(response);
        }
    }
}
