using System;

namespace Base.Domain.Commands.Prospect
{
    public class UpdateProspectCommand : ProspectCommand
    {
        public UpdateProspectCommand(Guid prospectId, string address, string firstName, string lastName, string cellPhone, bool isWhatsApp, string homePhone)
        {
            ProspectId = prospectId;
            Address = address;
            FirstName = firstName;
            LastName = lastName;
            CellPhone = cellPhone;
            IsWhatsApp = isWhatsApp;
            HomePhone = homePhone;
        }

        public Guid ProspectId { get; set; }

        public override void FillEntities()
        {
            base.FillEntities();
            Prospect.UpdateEntity(ProspectId);
        }
    }
}
