using System.Text.Json.Serialization;

namespace SPI_Update_Enterprise_Service.Domain.models.updateEnterprise
{
    public class ReqBPatchEnterprise
    {
        [JsonPropertyName("requestDateTime")]
        public string? requestDateTime { get; set; }

        [JsonPropertyName("entInfo")]
        public EntInfo? entInfo { get; set; }

        [JsonPropertyName("legalInfo")]
        public LegalInfo? legalInfo { get; set; }

        [JsonPropertyName("commerce")]
        public Commerce? commerce { get; set; }

        [JsonPropertyName("merchantId")]
        public string? merchantId { get; set; }
    }
}
