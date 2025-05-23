using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Cancellation_Service.Domain.models
{
    public class AditionalInfo
    {
    
        [JsonPropertyName("codigo")]
        public string? codigo { get; set; }

        [JsonPropertyName("detalle")]
        public string? detalle { get; set; }
    }
}
