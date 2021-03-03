using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace GloballyPaid
{
    public class Charge : Entity
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("response_code")]
        public string ResponseCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("approved")]
        public bool Approved { get; set; }

        [JsonProperty("source")]
        public PaymentInstrument Source { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("captured")]
        public bool Captured { get; set; }

        [JsonProperty("cvv")]
        public string CVV { get; set; }

        [JsonProperty("cof_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CofType CofType { get; set; }

        [JsonProperty("currency_code")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyCode CurrencyCode { get; set; }

        [JsonProperty("country_code")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryCode CountryCode { get; set; }

        [JsonProperty("billing_info")]
        public Contact BillingContact { get; set; }

        [JsonProperty("shipping_info")]
        public Contact ShippingContact { get; set; }

        [JsonProperty("client_transaction_id")]
        public string ClientTransactionId { get; set; }

        [JsonProperty("client_transaction_description")]
        public string ClientTransactionDescription { get; set; }

        [JsonProperty("client_invoice_id")]
        public string ClientInvoiceId { get; set; }

        [JsonProperty("save_payment_instrument")]
        public bool SavePaymentInstrument { get; set; }

        [JsonProperty("new_payment_instrument")]
        public PaymentInstrument NewPaymentInstrument { get; set; }

        [JsonProperty("kount_score")]
        public string KountScore { get; set; }

        [JsonProperty("completed")]
        public DateTime Completed { get; set; }

        [JsonProperty("fees", NullValueHandling = NullValueHandling.Ignore)]
        public List<Fee> Fees { get; set; }
    }
}

