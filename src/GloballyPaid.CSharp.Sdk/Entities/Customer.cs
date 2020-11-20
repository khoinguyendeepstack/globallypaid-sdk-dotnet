using Newtonsoft.Json;

namespace GloballyPaid
{
    public class Customer : Contact
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("client_customer_id")]
        public string ClientCustomerId { get; set; }
    }
}
