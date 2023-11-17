using System.Text.Json.Serialization;

namespace PagHiper.Responses
{
    public class StatusRequestResponse
    {
        [JsonPropertyName("status_request")]
        public BankSlipResponse? BankSlipResponse { get; set; }
    }
}
