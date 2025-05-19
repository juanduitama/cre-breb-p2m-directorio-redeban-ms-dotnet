using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SPI_Update_Service.Domain.models.redeban;

namespace domain.models.redeban
{
    public class Customer
    {
        /// <summary>
        /// Tipo de persona (PERSON o COMMERCE)
        /// </summary>
        [Required]
        [JsonPropertyName("Type")]
        public string? type { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [Required]
        [JsonPropertyName("Person")]
        public Person? person { get; set; }

    }
}
