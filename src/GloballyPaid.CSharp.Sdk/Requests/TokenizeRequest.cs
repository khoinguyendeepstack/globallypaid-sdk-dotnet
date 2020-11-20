using Newtonsoft.Json;

namespace GloballyPaid
{
    public class TokenizeRequest : Request
    {
        [JsonProperty("payment_instrument")]
        public PaymentInstrumentRequest PaymentInstrument { get; set; }

        [JsonProperty("traceId")]
        public string TraceId { get; set; }

        [JsonProperty("kount_session_id")]
        public string KountSessionId { get; set; }
    }
}
