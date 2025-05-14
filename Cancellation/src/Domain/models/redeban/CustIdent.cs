using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Cancellation_Service.Domain.models
{
    public class CustIdent
    {
        [JsonPropertyName("custIdentType")]
        public string custIdentType { get; set; }

        [JsonPropertyName("custIdentId")]
        public string custIdentId { get; set; }

    }
}
