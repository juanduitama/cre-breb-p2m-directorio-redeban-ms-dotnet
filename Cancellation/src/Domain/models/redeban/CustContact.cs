using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SPI_Cancellation_Service.Domain.models
{
    public class CustContact
    {
        [JsonPropertyName("custMobileNumber")]
        public string? custMobileNumber { get; set; }

        [JsonPropertyName("custEmail")]
        public string custEmail { get; set; }

    }
}
