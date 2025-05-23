using System.Text.Json.Serialization;

namespace SPI_Update_Enterprise_Service.Domain.models
{
    public class EntInfo    {
        

        [JsonPropertyName("nameEnterprise")]
        public string? nameEnterprise { get; set; }

        [JsonPropertyName("enterpriseType")]
        public string? enterpriseType { get; set; }

        [JsonPropertyName("entIdent")]
        public EntIdent? entIdent { get; set; }

        [JsonPropertyName("entContact")]
        public EntPostalAddress? entContact { get; set; }

    }
}
