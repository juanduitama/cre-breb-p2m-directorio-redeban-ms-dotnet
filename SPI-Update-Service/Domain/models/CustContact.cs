using System.Text.Json.Serialization;

namespace SPI_Update_Service.Domain.models
{
    public class CustContact
    {

        [JsonPropertyName("custMobileNumber")]
        public string? custMobileNumber { get; set; }

        [JsonPropertyName("custEmail")]
        public string custEmail { get; set; }
    }
}
