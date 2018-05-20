using System.Text.RegularExpressions;

namespace Base.ViewModel.ServiceApi
{
    public static class Config
    {
        public static string ApiUrl = "http://acheimeuape.azurewebsites.net";

        public static string ApiHostName
        {
            get
            {
                var apiHostName = Regex.Replace(ApiUrl, @"^(?:http(?:s)?://)?(?:www(?:[0-9]+)?\.)?", string.Empty, RegexOptions.IgnoreCase)
                                   .Replace("/", string.Empty);
                return apiHostName;
            }
        }
    }
}
