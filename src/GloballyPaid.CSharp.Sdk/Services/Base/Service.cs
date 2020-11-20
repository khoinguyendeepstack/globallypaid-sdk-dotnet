using System.Net.Http.Headers;

namespace GloballyPaid
{
    /// <summary>
    /// Base class for all Globally Paid services
    /// </summary>
    public abstract class Service
    {
        public Service()
        {
        }

        public Service(HttpServiceClient client)
        {
            Client = client;
        }

        private HttpServiceClient client;

        protected HttpServiceClient Client
        {
            get => client ?? GloballyPaidConfiguration.Client;
            set => client = value;
        }
        protected const string HMAC = "hmac";

        protected abstract string BasePath { get; }

        protected void TryReconfigureClient(object request, RequestOptions requestOptions = null)
        {
            TryReconfigureClient(requestOptions);

            Client.Headers.Remove(HMAC);
            
            var sharedSecret = requestOptions?.SharedSecret ?? GloballyPaidConfiguration.SharedSecret;
            var appId = requestOptions?.AppId ?? GloballyPaidConfiguration.AppId;
            
            Client.Headers.Add(HMAC, request.CreateHMAC(sharedSecret, appId));
        }

        protected void TryReconfigureClient(RequestOptions requestOptions = null)
        {
            if (requestOptions?.RequestTimeoutSeconds != default || requestOptions?.UseSandbox != default)
            {
                var useSandbox = requestOptions?.UseSandbox != default 
                    ? requestOptions.UseSandbox.GetValueOrDefault()
                    : GloballyPaidConfiguration.UseSandbox;

                var baseUrl = useSandbox
                    ? GloballyPaidConstants.DefaultSandboxBaseUrl
                    : GloballyPaidConstants.DefaultBaseUrl;

                var timeout = requestOptions?.RequestTimeoutSeconds != default
                    ? requestOptions?.RequestTimeoutSeconds
                    : GloballyPaidConfiguration.RequestTimeoutSeconds;

                Client = new HttpServiceClient(new HttpServiceClientConfiguration(baseUrl, timeout));
            }

            Client.AuthorizationHeader = new AuthenticationHeaderValue(GloballyPaidConstants.BearerAuthenticationScheme,
                requestOptions?.PublishableApiKey ?? GloballyPaidConfiguration.PublishableApiKey);
        }
    }
}
