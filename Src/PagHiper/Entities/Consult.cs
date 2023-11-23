using System.Text.Json.Serialization;

namespace PagHiper.Entities
{
    public class Consult
    {
        [JsonPropertyName("token")]
        public string? Token { get; set; }

        [JsonPropertyName("apiKey")]
        public string? ApiKey { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("transaction_id")]
        public string? TransactionId { get; set; }
    }
}
