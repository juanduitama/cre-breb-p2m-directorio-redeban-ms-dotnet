using System.Text.Json.Serialization;

namespace SPI_Update_Enterprise_Service.Domain.models
{
    public class Commerce
    {
        [JsonPropertyName("nameCommerce")]
        public string? nameCommerce { get; set; }


        [JsonPropertyName("alias")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? alias { get; set; }

        [JsonPropertyName("bankId")]
        public string? bankId { get; set; }

        [JsonPropertyName("commerceContact")]
        public EntPostalAddress? entCommerceContact { get; set; }
    }
}
