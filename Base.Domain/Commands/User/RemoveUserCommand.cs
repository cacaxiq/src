using Base.Shared.Domain.Command;
using System;

namespace Base.Domain.Commands.User
{
    public class RemoveUserCommand : Command
    {
        public RemoveUserCommand(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; private set; }
    }
}
