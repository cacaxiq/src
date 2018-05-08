using Base.Shared.Domain.Command;
using System;

namespace Base.Domain.Commands.Prospect
{
    public class RemoveProspectCommand : Command
    {
        public RemoveProspectCommand(Guid prospectId)
        {
            ProspectId = prospectId;
        }

        public Guid ProspectId { get; private set; }
    }
}
