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
        string? GetUserAvatarUrl(Guid userId, string avatarExtension);
        UserDetail? GetUserDetail(Guid userId);
        void SetUserAvatar(Guid userId, string extension, Stream stream);
        void SetUserDetail(UserDetail userDetail);
    }
}
