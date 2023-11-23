using System.Text.Json.Serialization;

namespace PagHiper.Entities
{
    public class Notification
    {
        [JsonPropertyName("apiKey")]
        public string? ApiKey { get; set; }

        [JsonPropertyName("token")]
        public string? Token { get; set; }

        [JsonPropertyName("transaction_id")]
        public string? TransactionId { get; set; }

        [JsonPropertyName("notification_id")]
        public string? NotificationId { get; set; }

        [JsonPropertyName("notification_date")]
        public DateTime? NotificationDate { get; set; }

        [JsonPropertyName("source_api")]
        public string? SourceApi { get; set; }
    }
}
