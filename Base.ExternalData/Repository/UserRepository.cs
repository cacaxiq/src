using Base.Domain.Entities;
using Base.Domain.Interface;
using Base.ExternalData.Context;
using System.Linq;

namespace Base.ExternalData.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BaseContext context) : base(context) { }

        public bool ExistUserWithEmailAndLogin(User user)
        {
            return DbSet.Any(c => c.Email.Address == user.Email.Address || c.UserID == user.UserID);
        }

        public User GetByUserID(string userID)
        {
            return DbSet.SingleOrDefault(c => c.UserID == userID);
        }
    }
}
