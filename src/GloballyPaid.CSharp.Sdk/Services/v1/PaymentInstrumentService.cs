using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GloballyPaid
{
    /// <summary>
    /// Service for Create, Read, Update and Delete of the <see cref="PaymentInstrument"/> entity
    /// </summary>
    public class PaymentInstrumentService : Service, IPaymentInstrumentService
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PaymentInstrumentService() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client"></param>
        public PaymentInstrumentService(HttpServiceClient client) : base(client) { }

        /// <summary>
        /// BasePath
        /// </summary>
        protected override string BasePath => $"api/v1/paymentinstrument";

        /// <summary>
        /// Sends a request to Globally Paid API to get all payment instruments
        /// </summary>
        /// <param name="customerId">The <see cref="Customer"/> Id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A list of <see cref="PaymentInstrument"/> entities</returns>
        public List<PaymentInstrument> List(string customerId, RequestOptions requestOptions = null)
        {
            TryReconfigureClient(requestOptions);
            return Client.Get<List<PaymentInstrument>>($"{BasePath}/list/{customerId}");
        }

        /// <summary>
        /// Sends a request to Globally Paid API to get all payment instruments, as an asynchronous operation
        /// </summary>
        /// <param name="customerId">The <see cref="Customer"/> Id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A list of <see cref="PaymentInstrument"/> Task entities, representing the asynchronous operation</returns>
        public async Task<List<PaymentInstrument>> ListAsync(string customerId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            TryReconfigureClient(requestOptions);
            return await Client.GetAsync<List<PaymentInstrument>>($"{BasePath}/list/{customerId}", checkResponseCode: false, cancellationToken);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to get a particular payment instrument by id
        /// </summary>
        /// <param name="id">The <see cref="PaymentInstrument"/> Id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="PaymentInstrument"/> entity</returns>
        public PaymentInstrument Get(string id, RequestOptions requestOptions = null)
        {
            TryReconfigureClient(requestOptions);
            return Client.Get<PaymentInstrument>($"{BasePath}/{id}");
        }

        /// <summary>
        /// Sends a request to Globally Paid API to get a particular payment instrument by id, as an asynchronous operation
        /// </summary>
        /// <param name="id">The <see cref="PaymentInstrument"/> Id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="PaymentInstrument"/> Task entity, representing the asynchronous operation</returns>
        public async Task<PaymentInstrument> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            TryReconfigureClient(requestOptions);
            return await Client.GetAsync<PaymentInstrument>($"{BasePath}/{id}", checkResponseCode: false, cancellationToken);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to create a payment instrument
        /// </summary>
        /// <param name="creditCardNumber">The credit card number</param>
        /// <param name="creditCardCvv">The credit card CVV</param>
        /// <param name="paymentInstrument">A <see cref="PaymentInstrument"/> entity to be created</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="PaymentInstrument"/> entity</returns>
        public PaymentInstrument Create(string creditCardNumber, string creditCardCvv, PaymentInstrument paymentInstrument, RequestOptions requestOptions = null)
        {
            var request = paymentInstrument.ToRequest(creditCardNumber, creditCardCvv);
            TryReconfigureClient(request, requestOptions);
            return Client.Post<PaymentInstrumentRequest, PaymentInstrument>(BasePath, request);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to create a payment instrument, as an asynchronous operation
        /// </summary>
        /// <param name="creditCardNumber">The credit card number</param>
        /// <param name="creditCardCvv">The credit card CVV</param>
        /// <param name="paymentInstrument">A <see cref="PaymentInstrument"/> entity to be created</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="PaymentInstrument"/> Task entity, representing the asynchronous operation</returns>
        public async Task<PaymentInstrument> CreateAsync(string creditCardNumber, string creditCardCvv, PaymentInstrument paymentInstrument, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            var request = paymentInstrument.ToRequest(creditCardNumber, creditCardCvv);
            TryReconfigureClient(request, requestOptions);
            return await Client.PostAsync<PaymentInstrumentRequest, PaymentInstrument>(BasePath, request, checkResponseCode: false, cancellationToken);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to updated a payment instrument
        /// </summary>
        /// <param name="creditCardNumber">The credit card number</param>
        /// <param name="creditCardCvv">The credit card CVV</param>
        /// <param name="paymentInstrument">A <see cref="PaymentInstrument"/> entity to be updated</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="PaymentInstrument"/> entity</returns>
        public PaymentInstrument Update(string creditCardNumber, string creditCardCvv, PaymentInstrument paymentInstrument, RequestOptions requestOptions = null)
        {
            var request = paymentInstrument.ToUpdateRequest();
            TryReconfigureClient(request, requestOptions);
            return Client.Put<UpdatePaymentInstrumentRequest, PaymentInstrument>($"{BasePath}/{paymentInstrument.Id}", request);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to updated a payment instrument, as an asynchronous operation
        /// </summary>
        /// <param name="creditCardNumber">The credit card number</param>
        /// <param name="creditCardCvv">The credit card CVV</param>
        /// <param name="paymentInstrument">A <see cref="PaymentInstrument"/> entity to be updated</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="PaymentInstrument"/> Task entity, representing the asynchronous operation</returns>
        public async Task<PaymentInstrument> UpdateAsync(string creditCardNumber, string creditCardCvv, PaymentInstrument paymentInstrument, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            var request = paymentInstrument.ToUpdateRequest();
            TryReconfigureClient(request, requestOptions);
            return await Client.PutAsync<UpdatePaymentInstrumentRequest, PaymentInstrument>($"{BasePath}/{paymentInstrument.Id}", request, checkResponseCode: false, cancellationToken);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to delete a payment instrument by id
        /// </summary>
        /// <param name="id">The <see cref="PaymentInstrument"/> id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        public void Delete(string id, RequestOptions requestOptions = null)
        {
            TryReconfigureClient(string.Empty, requestOptions);
            Client.Delete($"{BasePath}/{id}");
        }

        /// <summary>
        /// Sends a request to Globally Paid API to delete a payment instrument by id, as an asynchronous operation
        /// </summary>
        /// <param name="id">The <see cref="PaymentInstrument"/> id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A Task entity, representing the asynchronous operation</returns>
        public async Task DeleteAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            TryReconfigureClient(string.Empty, requestOptions);
            await Client.DeleteAsync($"{BasePath}/{id}", cancellationToken);
        }
    }
}
