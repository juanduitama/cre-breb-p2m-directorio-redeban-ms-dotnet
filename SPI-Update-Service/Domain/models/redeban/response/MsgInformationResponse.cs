using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace domain.models.redeban.response
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
