using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SPI_Cancellation_Service.Domain.models
{
    public class Data
    {
        [Required]
        [JsonPropertyName("merchantId")]
        public string? merchantId { get; set; }
    }
}
