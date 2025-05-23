using System.Text.Json.Serialization;

namespace SPI_Cancellation_Service.Domain.models.oAuth
{
    public class HeadersOAuth
    {
        /// <summary>
        /// Tipo de contenido
        /// </summary>
        [JsonPropertyName("Content-Type")]
        public string? contentType { get; set; }

        /// <summary>
        /// Credenciales de autenticación del sistema. (Secretos)
        /// </summary>
        [JsonPropertyName("X-IBM-Client-Id")] 
        public string? xIbmClientId { get; set; }

        /// <summary>
        /// Credenciales de autenticación del sistema. (Secretos)
        /// </summary>
        [JsonPropertyName("X-IBM-Client-Secret")] 
        public string? xIbmClientSecret { get; set; }
    }
}
