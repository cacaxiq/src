using Base.Shared.Domain.Command;
using System;

namespace Base.Domain.Commands.Prospect
{
    public class RemoveProspectCommand : Command
    {
        public Guid ProspectId { get; set; }
    }
}
