using System.Text.Json.Serialization;

namespace PagHiper.Responses
{
    public class BankSlipInfoResponse
    {
        [JsonPropertyName("digitable_line")]
        public string? DigitableLine { get; set; }

        [JsonPropertyName("url_slip")]
        public string? UrlSlip { get; set; }

        [JsonPropertyName("url_slip_pdf")]
        public string? UrlSlipPdf { get; set; }

        [JsonPropertyName("bar_code_number_to_image")]
        public string? BarCodeNumberToImage { get; set; }
    }
}
