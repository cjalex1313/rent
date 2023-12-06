using Rent.DAL;
using Rent.Domain.Entities.User;
using Rent.FileManager;

namespace Rent.BS.UserDetails
{
    public class UserDetailsService : IUserDetailsService
    {
        private readonly RentDbContext _dbContext;
        private readonly IFileManager _fileManager;

        public UserDetailsService(RentDbContext dbContext, IFileManager fileManager)
        {
            this._dbContext = dbContext;
            _fileManager = fileManager;
        }

        public string? GetUserAvatarUrl(Guid userId, string avatarExtension)
        {
            var avatarUrl = _fileManager.GetFileCDN($"avatars/{userId}{avatarExtension}");
            return avatarUrl;
        }

        public UserDetail? GetUserDetail(Guid userId)
        {
            var userDetail = _dbContext.UserDetails.FirstOrDefault(x => x.UserId == userId);
            return userDetail;
        }

        public void SetUserAvatar(Guid userId, string extension, Stream stream)
        {
            var key = $"avatars/{userId}{extension}";
            _fileManager.UploadFile(key, stream);
            var userDetail = _dbContext.UserDetails.FirstOrDefault(x => x.UserId == userId);
            if (userDetail == null)
            {
                userDetail = new UserDetail
                {
                    UserId = userId,
                    AvatarExtension = extension
                };
                _dbContext.UserDetails.Add(userDetail);
            }
            else
            {
                userDetail.AvatarExtension = extension;
            }
            _dbContext.SaveChanges();
        }

        public void SetUserDetail(UserDetail userDetail)
        {
            var dbUserDetail = _dbContext.UserDetails.FirstOrDefault(ud => ud.UserId == userDetail.UserId);
            if (dbUserDetail == null)
            {
                _dbContext.UserDetails.Add(userDetail);
            } else
            {
                dbUserDetail.FirstName = userDetail.FirstName;
                dbUserDetail.LastName = userDetail.LastName;
            }
            _dbContext.SaveChanges();
        }
    }
}
