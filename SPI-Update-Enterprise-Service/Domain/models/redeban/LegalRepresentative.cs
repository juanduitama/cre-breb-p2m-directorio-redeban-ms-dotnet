using System.Text.Json.Serialization;

namespace SPI_Update_Enterprise_Service.Domain.models.redeban
{
    public class LegalRepresentative
    {
        [JsonPropertyName("Name")]
        public string? name { get; set; }

        [JsonPropertyName("DocumentType")]
        public string? documentType { get; set; }

        [JsonPropertyName("DocumentNumber")]
        public string? documentNumber { get; set; }
       

        [JsonPropertyName("Email")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? email { get; set; }
        
        [JsonPropertyName("MobileNumber")]
        public string? mobileNumber { get; set; }
        
        [JsonPropertyName("DocummentIssuanceDate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime docummentIssuanceDate { get; set; }

    }
}
