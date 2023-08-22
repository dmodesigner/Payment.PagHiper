using System.Text.Json.Serialization;

namespace Domain.Requests
{
    public class ItemRequest
    {
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("item_id")]
        public string? ItemId { get; set; }

        [JsonPropertyName("price_cents")]
        public int PriceCents { get; set; }
    }
}
