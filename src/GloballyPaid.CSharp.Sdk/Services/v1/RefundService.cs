using System.Threading;
using System.Threading.Tasks;

namespace GloballyPaid
{
    /// <summary>
    /// Service for refunding charges
    /// </summary>
    public class RefundService : Service, IRefundService
    {
        public RefundService() { }

        public RefundService(HttpServiceClient client) : base(client) { }

        protected override string BasePath => $"api/v1/refund";

        /// <summary>
        /// Sends a request to Globally Paid API to refund a particular charge
        /// </summary>
        /// <param name="request">A <see cref="RefundRequest"/> request object</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="Refund"/> entity</returns>
        public Refund Refund(RefundRequest request, RequestOptions requestOptions = null)
        {
            TryReconfigureClient(request, requestOptions);
            return Client.Post<RefundRequest, Refund>(BasePath, request, checkResponseCode: true);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to refund a particular charge, as an asynchronous operation
        /// </summary>
        /// <param name="request">A <see cref="RefundRequest"/> request object</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="Refund"/> Task entity, representing the asynchronous operation</returns>
        public async Task<Refund> RefundAsync(RefundRequest request, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            TryReconfigureClient(request, requestOptions);
            return await Client.PostAsync<RefundRequest, Refund>(BasePath, request, checkResponseCode: true, cancellationToken);
        }
    }
}