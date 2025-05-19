using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SPI_Update_Service.Domain.models.redeban
{
        public class PersonContact
        {
        /**
         * Información de dirección y ubicación del cliente
         */
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            [JsonPropertyName("PostalAddress")]
            public PostalAddress? postalAddress { get; set; }

            /**
             * Numero de celular
             */
            [JsonPropertyName("MobileNumber")]
            public string? mobileNumber { get; set; }

        /**
         * Correo electronico
         */
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            [JsonPropertyName("Email")]
            public string? email { get; set; }
        }
}
