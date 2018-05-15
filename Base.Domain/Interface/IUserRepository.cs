using Base.Domain.Entities;
using Base.Shared.Domain.Interface;

namespace Base.Domain.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        bool ExistUserWithEmailAndLogin(User user);
        User GetByUserID(string userID);
    }
}
