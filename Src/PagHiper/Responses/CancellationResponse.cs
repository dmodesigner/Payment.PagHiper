using System.Text.Json.Serialization;

namespace PagHiper.Responses
{
    public class CancellationResponse
    {
        [JsonPropertyName("cancellation_request")]
        public BankSlipResponse? BankSlipResponse { get; set; }
    }
}
