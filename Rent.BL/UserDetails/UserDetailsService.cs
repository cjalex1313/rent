using Rent.DAL;
using Rent.Domain.Entities.User;

namespace Rent.BS.UserDetails
{
    public class UserDetailsService : IUserDetailsService
    {
        private readonly RentDbContext _dbContext;

        public UserDetailsService(RentDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public UserDetail? GetUserDetail(Guid userId)
        {
            var userDetail = _dbContext.UserDetails.FirstOrDefault(x => x.UserId == userId);
            return userDetail;
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
