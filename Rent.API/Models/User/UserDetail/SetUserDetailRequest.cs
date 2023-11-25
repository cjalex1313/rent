using Rent.API.Models.Base;

namespace Rent.API.Models.User.UserDetail
{
    public class SetUserDetailRequest : BaseRequest
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
    }
}
