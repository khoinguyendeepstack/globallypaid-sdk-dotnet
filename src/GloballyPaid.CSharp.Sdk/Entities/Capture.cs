using Newtonsoft.Json;
using System;

namespace GloballyPaid
{
    public class Capture : Entity
    {
        [JsonProperty("response_code")]
        public string ResponseCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("approved")]
        public bool Approved { get; set; }

        [JsonProperty("charge_transaction_id")]
        public string ChargeTransactionId { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("completed")]
        public DateTime Completed { get; set; }
    }
}
