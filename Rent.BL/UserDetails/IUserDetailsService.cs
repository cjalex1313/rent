using Rent.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.BS.UserDetails
{
    public interface IUserDetailsService
    {
        UserDetail? GetUserDetail(Guid userId);
        void SetUserDetail(UserDetail userDetail);
    }
}
