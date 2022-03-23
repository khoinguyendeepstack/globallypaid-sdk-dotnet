using Newtonsoft.Json;

namespace GloballyPaid
{
    public class PaymentSourceRawCard : PaymentSource
    {
        [JsonProperty("credit_card", Required = Required.Always)]
        public CreditCard CreditCard { get; set; }

        public PaymentSourceRawCard()
        {
            Type = PaymentSourceType.CREDIT_CARD;
        }
    }
}