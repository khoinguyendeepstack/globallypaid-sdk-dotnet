using System.Threading;
using System.Threading.Tasks;

namespace GloballyPaid
{
    /// <summary>
    /// Service for charging credit or debit card
    /// </summary>
    public class ChargeService : Service, IChargeService
    {
        protected override string BasePath => $"api/v1/charge";
        private readonly TokenService tokenService;

        public ChargeService()
        {
            if(tokenService == null)
            {
                tokenService = new TokenService();
            }
        }

        public ChargeService(HttpServiceClient client) : base(client) 
        {
            if (tokenService == null)
            {
                tokenService = new TokenService(client);
            }
        }

        /// <summary>
        /// Sends a request to Globally Paid API to charge credit or debit card that is previous tokenized
        /// </summary>
        /// <param name="request">A <see cref="ChargeRequest"/> request object</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="Charge"/> entity</returns>
        public Charge Charge(ChargeRequest request, RequestOptions requestOptions = null)
        {
            TryReconfigureClient(request, requestOptions);
            return Client.Post<ChargeRequest, Charge>(BasePath, request, checkResponseCode: true);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to charge credit or debit card that is previous tokenized, as an asynchronous operation
        /// </summary>
        /// <param name="request">A <see cref="ChargeRequest"/> request object</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="Charge"/> Task entity, representing the asynchronous operation</returns>
        public async Task<Charge> ChargeAsync(ChargeRequest request, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            TryReconfigureClient(request, requestOptions);
            return await Client.PostAsync<ChargeRequest, Charge>(BasePath, request, checkResponseCode: true, cancellationToken);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to tokenize and charge credit or debit card
        /// </summary>
        /// <param name="paymentInstrumentRequest">A <see cref="PaymentInstrumentRequest"/> request object</param>
        /// <param name="amount">A non-negative integer representing the smallest unit of the specified currency (example; 499 = $4.99 in USD)</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="Charge"/> entity</returns>
        public Charge Charge(PaymentInstrumentRequest paymentInstrumentRequest, long amount, RequestOptions requestOptions = null)
        {
            var paymentInstrument = tokenService.Tokenize(new TokenizeRequest
            {
                PaymentInstrument = paymentInstrumentRequest
            }, requestOptions);

            return Charge(new ChargeRequest
            {
                Source = paymentInstrument.Id,
                Amount = amount,
                Capture = true,
                SavePaymentInstrument = true
            }, requestOptions);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to tokenize and charge credit or debit card, as an asynchronous operation
        /// </summary>
        /// <param name="paymentInstrumentRequest">A <see cref="PaymentInstrumentRequest"/> request object</param>
        /// <param name="amount">A non-negative integer representing the smallest unit of the specified currency (example; 499 = $4.99 in USD)</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="Charge"/> Task entity, representing the asynchronous operation</returns>
        public async Task<Charge> ChargeAsync(PaymentInstrumentRequest paymentInstrumentRequest, long amount, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            var paymentInstrument = await tokenService.TokenizeAsync(new TokenizeRequest
            {
                PaymentInstrument = paymentInstrumentRequest
            }, requestOptions, cancellationToken);

            return await ChargeAsync(new ChargeRequest
            {
                Source = paymentInstrument.Id,
                Amount = amount,
                Capture = true,
                SavePaymentInstrument = true
            }, requestOptions, cancellationToken);
        }
    }
}