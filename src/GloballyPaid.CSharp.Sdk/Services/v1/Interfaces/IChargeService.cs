using System.Threading;
using System.Threading.Tasks;

namespace GloballyPaid
{
    /// <summary>
    /// Interface for charging credit or debit card
    /// </summary>
    public interface IChargeService
    {
        /// <summary>
        /// Sends a request to Globally Paid API to charge credit or debit card that is previous tokenized
        /// </summary>
        /// <param name="request">A <see cref="ChargeRequest"/> request object</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="Charge"/> entity</returns>
        Charge Charge(ChargeRequest request, RequestOptions requestOptions = null);

        /// <summary>
        /// Sends a request to Globally Paid API to charge credit or debit card that is previous tokenized, as an asynchronous operation
        /// </summary>
        /// <param name="request">A <see cref="ChargeRequest"/> request object</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="Charge"/> Task entity, representing the asynchronous operation</returns>
        Task<Charge> ChargeAsync(ChargeRequest request, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a request to Globally Paid API to tokenize and charge credit or debit card
        /// </summary>
        /// <param name="paymentInstrumentRequest">A <see cref="PaymentInstrumentRequest"/> request object</param>
        /// <param name="amount">A non-negative integer representing the smallest unit of the specified currency (example; 499 = $4.99 in USD)</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="Charge"/> entity</returns>
        Charge Charge(PaymentInstrumentRequest paymentInstrumentRequest, long amount, RequestOptions requestOptions = null);

        /// <summary>
        /// Sends a request to Globally Paid API to tokenize and charge credit or debit card, as an asynchronous operation
        /// </summary>
        /// <param name="paymentInstrumentRequest">A <see cref="PaymentInstrumentRequest"/> request object</param>
        /// <param name="amount">A non-negative integer representing the smallest unit of the specified currency (example; 499 = $4.99 in USD)</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="Charge"/> Task entity, representing the asynchronous operation</returns>
        Task<Charge> ChargeAsync(PaymentInstrumentRequest paymentInstrumentRequest, long amount, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
    }
}