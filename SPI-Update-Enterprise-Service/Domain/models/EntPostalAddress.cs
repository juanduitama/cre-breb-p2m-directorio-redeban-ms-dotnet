using System.Text.Json.Serialization;

namespace SPI_Update_Enterprise_Service.Domain.models
{
    public class EntPostalAddress
    {
        [JsonPropertyName("daneCode")]
        public string? daneCode { get; set; }

        [JsonPropertyName("address")]
        public string? address { get; set; }
        
        [JsonPropertyName("townName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? twonName { get; set; }
        
        [JsonPropertyName("country")]
        public string? country { get; set; }
    }
}
