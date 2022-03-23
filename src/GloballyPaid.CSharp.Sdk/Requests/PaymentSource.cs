using GloballyPaid.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GloballyPaid
{
    public class PaymentSource : IPaymentSource
    {
        [JsonProperty("type", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentSourceType Type { get; set; }

        [JsonProperty("billing_contact", NullValueHandling = NullValueHandling.Ignore)]
        public BillingContact BillingContact { get; set; }
        
    }
}