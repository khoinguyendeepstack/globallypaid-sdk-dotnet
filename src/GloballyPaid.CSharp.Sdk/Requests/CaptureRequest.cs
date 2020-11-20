using Newtonsoft.Json;

namespace GloballyPaid
{
    public class CaptureRequest : Request
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("charge")]
        public string Charge { get; set; }
    }
}