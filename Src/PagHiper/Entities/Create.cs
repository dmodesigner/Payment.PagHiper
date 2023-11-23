using System.Text.Json.Serialization;

namespace PagHiper.Entities
{
    public class Create
    {
        [JsonPropertyName("create_request")]
        public BankSlipResponse? BankSlipResponse { get; set; }
    }
}
