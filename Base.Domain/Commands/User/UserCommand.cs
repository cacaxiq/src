using Base.Domain.Entities;
using Base.Shared.Domain.Command;
using Base.Shared.Domain.ValueObjects;

namespace Base.Domain.Commands.User
{
    public abstract class UserCommand : Command
    {
        public string Address { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string AccessKey { get; protected set; }
        public string Login { get; protected set; }

        public Entities.User User { get; private set; }

        public override void FillEntities()
        {
            var name = new Name(FirstName, LastName);
            var email = new Email(Address);

            User = new Entities.User(name, email, AccessKey, Login);
        }
    }
}
