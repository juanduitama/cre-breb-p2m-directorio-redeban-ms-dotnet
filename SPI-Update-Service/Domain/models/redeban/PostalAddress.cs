using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SPI_Update_Service.Domain.models.redeban
{
    public class PostalAddress
    {

        /**
         * Información que localiza e identifica una dirección específica
         */
        [Required]
        [JsonPropertyName("Address")]
        public string? address;

        /**
         * Identificador formado por un grupo de letras y/o números que se añade a una dirección postal
         */
        [JsonPropertyName("PostalCode")]
        public string? postalCode;

        /**
         * Código de la Ciudad según el DANE
         */
        [Required]
        [JsonPropertyName("DaneCode")]
        public string? daneCode;

        /**
         * Nombre de un área rural, ciudad, municipio
         */
        [Required]
        [JsonPropertyName("TownName")]
        public string? townName;

        /**
         * País
         */
        [Required]
        [JsonPropertyName("Country")]
        public string? country;
    }
}

