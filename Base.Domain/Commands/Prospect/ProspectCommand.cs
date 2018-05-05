using Base.Shared.Domain.Command;
using Base.Shared.Domain.ValueObjects;
namespace Base.Domain.Commands.Prospect
{
    public abstract class ProspectCommand : Command
    {
        public string Address { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string CellPhone { get; protected set; }
        public bool IsWhatsApp { get; protected set; }
        public string HomePhone { get; protected set; }

        public Entities.Prospect Prospect { get; private set; }

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
            }

            AddNotifications(name, email, Prospect);
        }
    }
}
