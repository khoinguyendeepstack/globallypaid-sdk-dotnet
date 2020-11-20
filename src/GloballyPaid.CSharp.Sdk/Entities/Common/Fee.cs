using Newtonsoft.Json;

namespace GloballyPaid
{
    public class Fee : Entity
    {
        [JsonProperty("fee_type")]
        public string FeeType { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }
    }
}
