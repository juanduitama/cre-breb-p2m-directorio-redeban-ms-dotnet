using System.Text.Json.Serialization;

namespace SPI_Update_Enterprise_Service.Domain.models.redeban
{
    public class EnterpriseContact
    {
        [JsonPropertyName("PostalAddress")]
        public EntPostalAddress? postalAddress { get; set; }
    }
}
