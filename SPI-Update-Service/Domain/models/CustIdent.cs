using System.Text.Json.Serialization;

namespace SPI_Update_Service.Domain.models
{
    public class CustIdent
    {

        [JsonPropertyName("custIdentType")]
        public string custIdentType { get; set; }

        [JsonPropertyName("custIdentId")]
        public string custIdentId { get; set; }
    }
}
