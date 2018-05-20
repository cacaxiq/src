namespace Base.ViewModel.Model.Login
{
    public class UserInfoDTO : BaseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string UserId { get; set; }
        public string AccessKey { get; set; }
    }
}
