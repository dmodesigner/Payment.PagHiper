using System.Text.Json.Serialization;

namespace Domain.Requests
{
    public class BankSlipRequest
    {
        [JsonPropertyName("apiKey")]
        public string ApiKey { get; set; }

        [JsonPropertyName("order_id")]
        public string OrderId { get; set; }

        [JsonPropertyName("payer_email")]
        public string PayerEmail { get; set; }

        [JsonPropertyName("payer_name")]
        public string PayerName { get; set; }

        [JsonPropertyName("payer_cpf_cnpj")]
        public string PayerCpfCnpj { get; set; }

        [JsonPropertyName("payer_phone")]
        public int PayerPhone { get; set; }

        [JsonPropertyName("payer_street")]
        public string PayerStreet { get; set; }

        [JsonPropertyName("payer_number")]
        public int PayerNumber { get; set; }

        [JsonPropertyName("payer_complement")]
        public string PayerComplement { get; set; }

        [JsonPropertyName("payer_district")]
        public string PayerDistrict { get; set; }

        [JsonPropertyName("payer_city")]
        public string PayerCity { get; set; }

        [JsonPropertyName("payer_state")]
        public string PayerState { get; set; }

        [JsonPropertyName("payer_zip_code")]
        public int PayerZipCode { get; set; }

        [JsonPropertyName("notification_url")]
        public string NotificationUrl { get; set; }

        [JsonPropertyName("discount_cents")]
        public int DiscountCents { get; set; }

        [JsonPropertyName("shipping_price_cents")]
        public int ShippingPriceCents { get; set; }

        [JsonPropertyName("shipping_methods")]
        public string ShippingMethods { get; set; }

        [JsonPropertyName("fixed_description")]
        public bool FixedDescription { get; set; }

        [JsonPropertyName("days_due_date")]
        public int DaysDueDate { get; set; }

        [JsonPropertyName("type_bank_slip")]
        public string TypeBankSlip { get => "boletoA4"; }

        [JsonPropertyName("items")]
        public List<ItemRequest> Items { get; set; }
    }
}
