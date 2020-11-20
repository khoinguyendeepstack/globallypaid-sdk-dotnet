namespace GloballyPaid
{
    public class HttpServiceClientConfiguration
    {
        public HttpServiceClientConfiguration(string baseUrl)
        {
            BaseUrl = baseUrl;
            AcceptsMimeType = GloballyPaidConstants.ApplicationJson;
            TimeoutSeconds = GloballyPaidConstants.DefaultTimoutSeconds;
        }

        public HttpServiceClientConfiguration(string baseUrl, string acceptsMimeType)
            : this(baseUrl)
        {
            AcceptsMimeType = acceptsMimeType;
        }

        public HttpServiceClientConfiguration(string baseUrl, int? timeoutSeconds)
            : this(baseUrl)
        {
            TimeoutSeconds = timeoutSeconds ?? GloballyPaidConstants.DefaultTimoutSeconds;
        }

        public HttpServiceClientConfiguration(string baseUrl, string acceptsMimeType, int timeoutSeconds)
            : this(baseUrl, acceptsMimeType)
        {
            TimeoutSeconds = timeoutSeconds;
        }

        public HttpServiceClientConfiguration(string baseUrl, string authenticationScheme, string authenticationValue, int timeoutSeconds = GloballyPaidConstants.DefaultTimoutSeconds)
            : this(baseUrl)
        {
            AuthenticationScheme = authenticationScheme;
            AuthenticationValue = authenticationValue;
            TimeoutSeconds = timeoutSeconds != default 
                ? timeoutSeconds 
                : GloballyPaidConstants.DefaultTimoutSeconds;
        }

        public string BaseUrl { get; set; }
        public string AuthenticationScheme { get; set; }
        public string AuthenticationValue { get; set; }
        public string AcceptsMimeType { get; set; }
        public int TimeoutSeconds { get; set; }
    }
}
