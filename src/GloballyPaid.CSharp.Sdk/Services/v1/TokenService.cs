using System.Threading;
using System.Threading.Tasks;

namespace GloballyPaid
{
    /// <summary>
    /// Service to tokenize the card data
    /// </summary>
    public class TokenService : Service, ITokenService
    {
        public TokenService() { }

        public TokenService(HttpServiceClient client) : base(client) { }

        protected override string BasePath => $"api/v1/token";

        /// <summary>
        /// Sends a request to Globally Paid API to tokenize particular card data
        /// </summary>
        /// <param name="request">A <see cref="TokenizeRequest"/> request object</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="PaymentInstrument"/> entity</returns>
        public PaymentInstrument Tokenize(TokenizeRequest request, RequestOptions requestOptions = null)
        {
            TryReconfigureClient(requestOptions);
            return Client.Post<TokenizeRequest, PaymentInstrument>(BasePath, request);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to tokenize particular card data, as an asynchronous operation
        /// </summary>
        /// <param name="request">A <see cref="TokenizeRequest"/> request object</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="PaymentInstrument"/> Task entity, representing the asynchronous operation</returns>
        public async Task<PaymentInstrument> TokenizeAsync(TokenizeRequest request, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            TryReconfigureClient(requestOptions);
            return await Client.PostAsync<TokenizeRequest, PaymentInstrument>(BasePath, request, checkResponseCode: false, cancellationToken);
        }
    }
}
