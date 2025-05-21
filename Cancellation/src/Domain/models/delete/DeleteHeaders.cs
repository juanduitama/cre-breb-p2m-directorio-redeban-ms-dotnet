using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SPI_Cancellation_Service.Domain.models.delete
{
    public class DeleteHeaders
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