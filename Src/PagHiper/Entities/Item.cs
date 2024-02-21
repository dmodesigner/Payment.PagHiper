using System.Text.Json.Serialization;

namespace PagHiper.Entities;

public class Item
{
    [JsonPropertyName("item_id")]
    public string? ItemId { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("price_cents")]
    public int PriceCents { get; set; }
}
