using Base.Shared.Domain.Command;
using System;

namespace Base.Domain.Commands
{
    public class RemoveIntentionCommand : Command
    {
        public RemoveIntentionCommand(Guid intenttionId)
        {
            IntenttionId = intenttionId;
        }

        public Guid IntenttionId { get; private set; }
    }
}
