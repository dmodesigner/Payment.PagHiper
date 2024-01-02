using System.Text.Json.Serialization;

namespace PagHiper.Entities
{
    public class Bank
    {
        [JsonPropertyName("bank_code")]
        public string? BankCode { get; set; }

        [JsonPropertyName("bank_name")]
        public string? BankName { get; set; }

        [JsonPropertyName("account_type")]
        public string? AccountType { get; set; }

        [JsonPropertyName("bank_account_id")]
        public int? BankAccountId { get; set; }
    }
}
