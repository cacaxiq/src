namespace Base.WebApi.Security
{
    public class TokenConfigurations
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
        public int Minutes { get; set; }
        public int Days { get; set; }
        public int FinalExpiration { get; set; }
    }
}
