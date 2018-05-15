namespace Base.WebApi.Security
{
    public class TokenConfigurations
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Time { get; set; }
        public string Type { get; set; }
        public int FinalExpiration { get; set; }
    }
}
