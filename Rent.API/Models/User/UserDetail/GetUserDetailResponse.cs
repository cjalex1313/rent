using Rent.API.Models.Base;

namespace Rent.API.Models.User.UserDetail
{
    public class GetUserDetailResponse : BaseResponse
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set;}

        public GetUserDetailResponse(Domain.Entities.User.UserDetail? userDetail)
        {
            if (userDetail != null)
            {
                FirstName = userDetail.FirstName;
                LastName = userDetail.LastName;
            }
        }
    }
}
