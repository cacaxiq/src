namespace Base.WebApi.Security
{
    public class AccessCredentials
    {
        public string UserID { get; set; }
        public string AccessKey { get; set; }
        public string RefreshToken { get; set; }
        public string GrantType { get; set; }
    }
}
