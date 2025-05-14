using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SPI_Cancellation_Service.Domain.models.redeban.response;

namespace SPI_Cancellation_Service.Domain.models
{
    public class TimeStamps
    {

        /**
         *
         */
        [JsonPropertyName("Envelope")]
        public Envelope? envelope { get; set; }
    }
}
