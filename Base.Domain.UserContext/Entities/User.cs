using Base.Shared.Domain.Entities;
using Base.Shared.Domain.ValueObjects;

namespace Base.Domain.UserContext.Entities
{
    public class User : BaseUser
    {
        public User(
            Name name, 
            Email email, 
            CellPhone cellPhone, 
            HomePhone homePhone) : base(
                name, 
                email, 
                cellPhone, 
                homePhone)
        {
        }
    }
}
