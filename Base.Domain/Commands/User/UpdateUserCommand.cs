using System;

namespace Base.Domain.Commands.User
{
    public class UpdateUserCommand : UserCommand
    {
        public UpdateUserCommand(Guid userId,string address, string firstName, string lastName, string accessKey, string login)
        {
            UserId = userId;
            Address = address;
            FirstName = firstName;
            LastName = lastName;
            AccessKey = accessKey;
            Login = login;
        }

        public Guid UserId { get; set; }

        public override void FillEntities()
        {
            base.FillEntities();
            User.UpdateEntity(UserId);
        }
    }
}
