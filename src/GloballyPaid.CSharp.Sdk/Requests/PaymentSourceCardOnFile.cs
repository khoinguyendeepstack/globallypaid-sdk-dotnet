using System.ComponentModel;
using Newtonsoft.Json;

namespace GloballyPaid
{
    public class PaymentSourceCardOnFile : PaymentSource
    {
        [JsonProperty("card_on_file", Required = Required.Always)]
        public CardOnFile CardOnFile { get; set; }

        public PaymentSourceCardOnFile()
        {
            Type = PaymentSourceType.CARD_ON_FILE;
        }
    }

    public class CardOnFile
    {
        [JsonProperty("id", Required = Required.Always)]
        public string Id;
        
        [JsonProperty("cvv")]
        [Description("The CVV or CVC code usually on the back of the card")]
        public string CVV { get; set; }
    }
}