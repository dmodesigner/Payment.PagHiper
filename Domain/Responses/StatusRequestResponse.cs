using System.Text.Json.Serialization;

namespace Domain.Responses
{
    internal class StatusRequestResponse
    {
        [JsonPropertyName("status_request")]
        public BankSlipResponse? BankSlipResponse { get; set; }
    }
}
