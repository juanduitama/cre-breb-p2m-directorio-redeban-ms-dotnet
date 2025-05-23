using System.Text.Json.Serialization;

namespace SPI_Update_Enterprise_Service.Domain.models.redeban
{
    public class CommerceRed
    {
        [JsonPropertyName("NameCommerce")]
        public string? nameCommerce { get; set; }

        [JsonPropertyName("Alias")]
        public string? alias { get; set; }

        [JsonPropertyName("PostalAddress")]
        public EntPostalAddress? entPostalAddress { get; set; }


    }
}
