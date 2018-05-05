namespace Base.Domain.Commands.Prospect
{
    public class CreateProspectCommand : ProspectCommand
    {
        public CreateProspectCommand(string address, string firstName, string lastName, string cellPhone, bool isWhatsApp, string homePhone)
        {
            Address = address;
            FirstName = firstName;
            LastName = lastName;
            CellPhone = cellPhone;
            IsWhatsApp = isWhatsApp;
            HomePhone = homePhone;
        }
    }
}
