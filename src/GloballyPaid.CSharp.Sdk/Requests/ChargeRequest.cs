using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace GloballyPaid
{
    public class ChargeRequest : Request
    {
        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("client_customer_id")]
        public string ClientCustomerId { get; set; }

        [JsonProperty("capture")]
        public bool Capture { get; set; } = true;

        [JsonProperty("recurring")]
        public bool Recurring { get; set; }

        [JsonProperty("currency_code")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyCode CurrencyCode { get; set; } = CurrencyCode.USD;

        [JsonProperty("country_code")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryCode CountryCode { get; set; } = CountryCode.US;

        [JsonProperty("client_transaction_id")]
        public string ClientTransactionId { get; set; } = "00000";

        [JsonProperty("client_transaction_description")]
        public string ClientTransactionDescription { get; set; } = "No Description";

        [JsonProperty("client_invoice_id")]
        public string ClientInvoiceId { get; set; } = "00000";

        [JsonProperty("session_id")]
        public string SessionId { get; set; }

        [JsonProperty("avs")]
        public bool AVS { get; set; }

        [JsonProperty("user_agent")]
        public string UserAgent { get; set; }

        [JsonProperty("browser_header")]
        public string BrowserHeader { get; set; }

        [JsonProperty("save_payment_instrument")]
        public bool SavePaymentInstrument { get; set; }

        [JsonProperty("shipping_info")]
        public Contact ShippingContact { get; set; }

        [JsonProperty("fees", NullValueHandling = NullValueHandling.Ignore)]
        public List<Fee> Fees { get; set; }
    }
}