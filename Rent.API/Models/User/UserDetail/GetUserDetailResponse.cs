using Rent.API.Models.Base;
using Rent.BS.UserDetails;

namespace Rent.API.Models.User.UserDetail
{
    public class GetUserDetailResponse : BaseResponse
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        public string? AvatarUrl { get; set; }

        public GetUserDetailResponse(Domain.Entities.User.UserDetail? userDetail, IUserDetailsService userDetailsService)
        {
            if (userDetail != null)
            {
                FirstName = userDetail.FirstName;
                LastName = userDetail.LastName;
                if (userDetail.AvatarExtension != null)
                {
                    AvatarUrl = userDetailsService.GetUserAvatarUrl(userDetail.UserId, userDetail.AvatarExtension);
                }
            }
        }
    }
}
