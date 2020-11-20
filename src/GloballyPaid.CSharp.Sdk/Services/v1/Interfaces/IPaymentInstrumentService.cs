using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GloballyPaid
{
    /// <summary>
    /// Interface for Create, Read, Update and Delete of the <see cref="PaymentInstrument"/> entity
    /// </summary>
    public interface IPaymentInstrumentService
    {
        /// <summary>
        /// Sends a request to Globally Paid API to get all payment instruments
        /// </summary>
        /// <param name="customerId">The <see cref="Customer"/> Id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A list of <see cref="PaymentInstrument"/> entities</returns>
        List<PaymentInstrument> List(string customerId, RequestOptions requestOptions = null);

        /// <summary>
        /// Sends a request to Globally Paid API to get all payment instruments, as an asynchronous operation
        /// </summary>
        /// <param name="customerId">The <see cref="Customer"/> Id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A list of <see cref="PaymentInstrument"/> Task entities, representing the asynchronous operation</returns>
        Task<List<PaymentInstrument>> ListAsync(string customerId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a request to Globally Paid API to get a particular payment instrument by id
        /// </summary>
        /// <param name="id">The <see cref="PaymentInstrument"/> Id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="PaymentInstrument"/> entity</returns>
        PaymentInstrument Get(string id, RequestOptions requestOptions = null);

        /// <summary>
        /// Sends a request to Globally Paid API to get a particular payment instrument by id, as an asynchronous operation
        /// </summary>
        /// <param name="id">The <see cref="PaymentInstrument"/> Id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="PaymentInstrument"/> Task entity, representing the asynchronous operation</returns>
        Task<PaymentInstrument> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a request to Globally Paid API to create a payment instrument
        /// </summary>
        /// <param name="creditCardNumber">The credit card number</param>
        /// <param name="creditCardCvv">The credit card CVV</param>
        /// <param name="paymentInstrument">A <see cref="PaymentInstrument"/> entity to be created</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="PaymentInstrument"/> entity</returns>
        PaymentInstrument Create(string creditCardNumber, string creditCardCvv, PaymentInstrument paymentInstrument, RequestOptions requestOptions = null);

        /// <summary>
        /// Sends a request to Globally Paid API to create a payment instrument, as an asynchronous operation
        /// </summary>
        /// <param name="creditCardNumber">The credit card number</param>
        /// <param name="creditCardCvv">The credit card CVV</param>
        /// <param name="paymentInstrument">A <see cref="PaymentInstrument"/> entity to be created</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="PaymentInstrument"/> Task entity, representing the asynchronous operation</returns>
        Task<PaymentInstrument> CreateAsync(string creditCardNumber, string creditCardCvv, PaymentInstrument paymentInstrument, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a request to Globally Paid API to updated a payment instrument
        /// </summary>
        /// <param name="creditCardNumber">The credit card number</param>
        /// <param name="creditCardCvv">The credit card CVV</param>
        /// <param name="paymentInstrument">A <see cref="PaymentInstrument"/> entity to be updated</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="PaymentInstrument"/> entity</returns>
        PaymentInstrument Update(string creditCardNumber, string creditCardCvv, PaymentInstrument paymentInstrument, RequestOptions requestOptions = null);

        /// <summary>
        /// Sends a request to Globally Paid API to updated a payment instrument, as an asynchronous operation
        /// </summary>
        /// <param name="creditCardNumber">The credit card number</param>
        /// <param name="creditCardCvv">The credit card CVV</param>
        /// <param name="paymentInstrument">A <see cref="PaymentInstrument"/> entity to be updated</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="PaymentInstrument"/> Task entity, representing the asynchronous operation</returns>
        Task<PaymentInstrument> UpdateAsync(string creditCardNumber, string creditCardCvv, PaymentInstrument paymentInstrument, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a request to Globally Paid API to delete a payment instrument by id
        /// </summary>
        /// <param name="id">The <see cref="PaymentInstrument"/> id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        void Delete(string id, RequestOptions requestOptions = null);

        /// <summary>
        /// Sends a request to Globally Paid API to delete a payment instrument by id, as an asynchronous operation
        /// </summary>
        /// <param name="id">The <see cref="PaymentInstrument"/> id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A Task entity, representing the asynchronous operation</returns>
        Task DeleteAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
    }
}
