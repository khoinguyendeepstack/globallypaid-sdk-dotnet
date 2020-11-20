using Newtonsoft.Json;

namespace GloballyPaid
{
    public class CreditCard : Entity
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("expiration")]
        public string Expiration { get; set; }

        [JsonProperty("cvv")]
        public string Cvv { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("last_four")]
        public string LastFour { get; set; }

    }
}
