using System.Text.Json.Serialization;

namespace Domain.Responses
{
    public class CreateBankSlipResponse
    {
        [JsonPropertyName("result")]
        public string Result { get; set; }

        [JsonPropertyName("response_message")]
        public string ResponseMessage { get; set; }

        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; }

        [JsonPropertyName("created_date")]
        public string CreatedDate { get; set; }

        [JsonPropertyName("value_cents")]
        public string ValueCents { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("order_id")]
        public string OrderId { get; set; }

        [JsonPropertyName("due_date")]
        public DateTime DueDate { get; set; }

        [JsonPropertyName("bank_slip")]
        public BankSlipResponse BankSlip { get; set; }

        [JsonPropertyName("http_code")]
        public int HttpCode { get; set; }
    }
}
