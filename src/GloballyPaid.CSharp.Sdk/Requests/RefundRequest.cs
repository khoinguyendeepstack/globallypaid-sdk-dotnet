using Newtonsoft.Json;

namespace GloballyPaid
{
    public class RefundRequest : Request
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("charge")]
        public string Charge { get; set; }
    }
}