using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Update_Enterprise_Service.Domain.models.redeban.response
{
    public class MsgInformationResponse
    {

        /**
         * Objeto del mensaje de respuesta
         */
        [JsonPropertyName("MessageInformation")]
        public MessageInformation? messageInformation { get; set; }
    }
}
