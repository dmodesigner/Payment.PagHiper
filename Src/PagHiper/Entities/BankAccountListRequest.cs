using System.Text.Json.Serialization;

namespace PagHiper.Entities;

internal class BankAccountListRequest
{
    [JsonPropertyName("bank_account_list_request")]
    public BankAccount? BankAccount { get; set; }
}
