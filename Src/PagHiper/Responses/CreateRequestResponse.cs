using System.Text.Json.Serialization;

namespace PagHiper.Responses
{
    public class CreateRequestResponse
    {
        [JsonPropertyName("create_request")]
        public BankSlipResponse? BankSlipResponse { get; set; }
    }
}
