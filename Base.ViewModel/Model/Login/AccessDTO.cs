using System;

namespace Base.ViewModel.Model.Login
{
    public class AccessDTO : BaseDTO
    {
        public bool Authenticated { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Expiration { get; set; }
        public string AccessToken { get; set; }
        public UserInfoDTO User { get; set; }
    }
}
