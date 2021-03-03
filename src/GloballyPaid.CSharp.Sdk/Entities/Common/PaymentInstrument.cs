using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace GloballyPaid
{
    public class PaymentInstrument : Entity
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentType Type { get; set; }

        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty("client_customer_id")]
        public string ClientCustomerId { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("last_four")]
        public string LastFour { get; set; }

        [JsonProperty("expiration")]
        public string Expiration { get; set; }

        [JsonProperty("billing_contact")]
        public Contact BillingContact { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        internal PaymentInstrumentRequest ToRequest(string creditCardNumber, string creditCardCvv)
        {
            return new PaymentInstrumentRequest
            {
                Id = Id,
                Type = Type,
                CustomerId = CustomerId,
                ClientCustomerId = ClientCustomerId,
                BillingContact = BillingContact,
                CreditCard = new CreditCard
                {
                    Brand = Brand,
                    LastFour = LastFour,
                    Expiration = Expiration,
                    Number = creditCardNumber,
                    Cvv = creditCardCvv
                }
            };
        }

        internal UpdatePaymentInstrumentRequest ToUpdateRequest()
        {
            return new UpdatePaymentInstrumentRequest
            {
                Id = Id,
                Type = Type,
                CustomerId = CustomerId,
                ClientCustomerId = ClientCustomerId,
                BillingContact = BillingContact,
            };
        }
    }
}
