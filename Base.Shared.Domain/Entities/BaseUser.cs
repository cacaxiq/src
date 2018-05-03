using Base.Shared.Domain.ValueObjects;

namespace Base.Shared.Domain.Entities
{
    public abstract class BaseUser : Entity
    {
        public BaseUser(Name name, Email email)
        {
            Name = name;
            Email = email;

            AddNotifications(name, email);
        }

        protected BaseUser() { }

        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public CellPhone CellPhone { get; private set; }
        public HomePhone HomePhone { get; private set; }

        public void AddHomePhone(HomePhone homePhone)
        {
            if (homePhone.Valid)
                HomePhone = homePhone;
            else
                AddNotifications(homePhone);
        }

        public void AddCellPhone(CellPhone cellPhone)
        {
            if (cellPhone.Valid)
                CellPhone = cellPhone;
            else
                AddNotifications(cellPhone);
        }
    }
}
