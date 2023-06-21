using System;
using System.Net;

namespace DeepStack.Core
{
    /// <summary>
    /// DeepStack custom exception class, thrown each time there is an error with some service call
    /// </summary>
    public class DeepStackException : Exception
    {
        public DeepStackException()
        {
        }

        public DeepStackException(string message) : base(message)
        {
        }

        public DeepStackException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public DeepStackException(HttpStatusCode httpStatusCode, string errorMessage, HttpServiceClientResponse globallyPaidResponse)
        {
            HttpStatusCode = httpStatusCode;
            ErrorMessage = !string.IsNullOrWhiteSpace(errorMessage) ? errorMessage : GetErrorMessageFromStatusCode(httpStatusCode);
            GloballyPaidResponse = globallyPaidResponse;
        }

        /// <summary>
        /// The HTTP status code that is returned from the Globally Paid API
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// The Error message
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// The Original response from the Globally Paid API
        /// </summary>
        public HttpServiceClientResponse GloballyPaidResponse { get; set; }

        private string GetErrorMessageFromStatusCode(HttpStatusCode httpStatusCode)
        {
            return DeepStackConstants.ErrorStatusCodes.ContainsKey(httpStatusCode)
                ? DeepStackConstants.ErrorStatusCodes[httpStatusCode]
                : string.Empty;
        }
    }
}
 