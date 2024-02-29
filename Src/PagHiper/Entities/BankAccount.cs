using System.Text.Json.Serialization;

namespace PagHiper.Entities;

public class BankAccount
{
    [JsonPropertyName("result")]
    public string? Result { get; set; }

    [JsonPropertyName("response_message")]
    public string? ResponseMessage { get; set; }

    [JsonPropertyName("bank_account_list")]
    public List<Bank>? BankList { get; set; }

    [JsonPropertyName("http_code")]
    public int? HttpCode { get; set; }
}
