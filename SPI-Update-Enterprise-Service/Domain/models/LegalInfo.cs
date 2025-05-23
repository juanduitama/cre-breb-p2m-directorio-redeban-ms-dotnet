using System.Text.Json.Serialization;

namespace SPI_Update_Enterprise_Service.Domain.models
{
    public class LegalInfo
    {
        [JsonPropertyName("name")]
        public string? nameRl { get; set; }

        [JsonPropertyName("mobileNumber")]
        public string? mobileNumber { get; set; }
        
        [JsonPropertyName("email")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? email { get; set; }
        
        [JsonPropertyName("documentIssuanceDate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime documentIssuanceDate { get; set; }

        [JsonPropertyName("entIdentRl")]
        public EntIdent? entIdentRl { get; set; }
    }
}
