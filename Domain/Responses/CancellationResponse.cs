using System.Text.Json.Serialization;

namespace Domain.Responses
{
    public class CancellationResponse
    {
        [JsonPropertyName("cancellation_request")]
        public BankSlipResponse? BankSlipResponse { get; set; }
    }
}
