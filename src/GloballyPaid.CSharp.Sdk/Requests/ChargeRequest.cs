using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using GloballyPaid.Interface;

namespace GloballyPaid
{
    public class ChargeRequest : Request
    {
        /// <summary>
        /// The ID of the payment method to be charged
        /// </summary>
        [JsonProperty("source", Required = Required.Always)]
        public IPaymentSource Source { get; set; }

        [JsonProperty("transaction")]
        public TransactionParameters Params { get; set; }
        
        [JsonProperty("meta")]
        public TransactionMeta Meta { get; set; }
    }
}