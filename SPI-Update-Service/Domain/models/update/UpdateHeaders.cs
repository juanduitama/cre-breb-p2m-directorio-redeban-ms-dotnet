using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace domain.models.enrollment
{
    public class UpdateHeaders
    {  
        [JsonPropertyName("ipOrgin")]
        public string ipOrigin { get; set; }

        
        [JsonPropertyName("uuId")]
        public string uuId { get; set; }

        
        [JsonPropertyName("timeStamp")]
        public string timeStamp { get; set; }

        
        [JsonPropertyName("systemId")]
        public string systemId { get; set; }
    }
}