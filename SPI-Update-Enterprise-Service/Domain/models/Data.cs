using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SPI_Cancellation_Service.Domain.models
{
    public class Data
    {
        
        [JsonPropertyName("merchantId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? merchantId { get; set; }
    }
}
