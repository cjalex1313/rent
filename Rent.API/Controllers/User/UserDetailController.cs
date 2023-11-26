using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
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
            var response = new GetUserDetailResponse(userDetail);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Set([FromBody] SetUserDetailRequest request) { 
            var userId = GetUserId();
            var userDetail = new UserDetail
            {
                UserId = userId,
                FirstName = request.FirstName,
                LastName = request.LastName
            };
            _userDetailsService.SetUserDetail(userDetail);
            var response = new GetUserDetailResponse(userDetail);
            return Ok(response);
        }
    }
}
