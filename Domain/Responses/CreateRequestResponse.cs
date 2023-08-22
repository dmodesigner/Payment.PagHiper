using System.Text.Json.Serialization;

namespace Domain.Responses
{
    public class CreateRequestResponse
    {
        [JsonPropertyName("create_request")]
        public BankSlipResponse BankSlipResponse { get; set; }
    }
}
