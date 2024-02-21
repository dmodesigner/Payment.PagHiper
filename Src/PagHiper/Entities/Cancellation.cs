using System.Text.Json.Serialization;

namespace PagHiper.Entities;

public class Cancellation
{
    [JsonPropertyName("cancellation_request")]
    public BankSlipResponse? BankSlipResponse { get; set; }
}
