using Base.Domain.Entities;
using Base.Domain.Interface;
using Base.ExternalData.Context;

namespace Base.ExternalData.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BaseContext context) : base(context) { }
    }
}
