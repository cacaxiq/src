using System;

namespace Base.Domain.Commands.Prospect
{
    public class EditProspectCommand : ProspectCommand
    {
        public Guid ProspectId { get; set; }

        public override void FillEntities()
        {
            base.FillEntities();
            Prospect.UpdateEntity(ProspectId);
        }
    }
}
