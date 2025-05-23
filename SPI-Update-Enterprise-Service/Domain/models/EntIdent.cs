using System.Text.Json.Serialization;

namespace SPI_Update_Enterprise_Service.Domain.models
{
    public class EntIdent
    {
        [JsonPropertyName("entIdentType")]
        public string? entIdentType { get; set; }

        [JsonPropertyName("entIdentId")]
        public string? entIdentId { get; set; }

    }
}
