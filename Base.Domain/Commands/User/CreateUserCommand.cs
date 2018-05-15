namespace Base.Domain.Commands.User
{
    public class CreateUserCommand : UserCommand
    {
        public CreateUserCommand(string address, string firstName, string lastName, string accessKey, string login)
        {
            Address = address;
            FirstName = firstName;
            LastName = lastName;
            AccessKey = accessKey;
            Login = login;
        }
    }
}
