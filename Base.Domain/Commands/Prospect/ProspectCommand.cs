using Base.Shared.Domain.Command;
using Base.Shared.Domain.ValueObjects;
namespace Base.Domain.Commands.Prospect
{
    public class ProspectCommand : Command
    {
        public string Address { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string CellPhone { get; private set; }
        public bool IsWhatsApp { get; private set; }
        public string HomePhone { get; private set; }

        public Entities.Prospect Prospect { get; set; }

        public override void FillEntities()
        {
            var name = new Name(FirstName, LastName);
            var email = new Email(Address);

            Prospect = new Entities.Prospect(name, email);

            if (!string.IsNullOrEmpty(CellPhone))
            {
                var cellPhone = new CellPhone(CellPhone, IsWhatsApp);
                Prospect.AddCellPhone(cellPhone);
            }

            if (!string.IsNullOrEmpty(HomePhone))
            {
                var homePhone = new HomePhone(HomePhone);
                Prospect.AddHomePhone(homePhone);

                AddNotifications(name, email, Prospect);
            }
        }
    }
}
