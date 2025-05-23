using System.Text.Json.Serialization;

namespace SPI_Update_Enterprise_Service.Domain.models.updateEnterprise
{
    public class UpdateHeadersEnterprise
    {
        [JsonPropertyName("ipOrigin")]
        public string? ipOrigin { get; set; }


        [JsonPropertyName("uuId")]
        public string? uuId { get; set; }


        [JsonPropertyName("timeStamps")]
        public string? timeStamps { get; set; }


        [JsonPropertyName("systemId")]
        public string? systemId { get; set; }
    }
}
