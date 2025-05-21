using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

namespace SPI_Cancellation_Service.Domain.models.delete
{
    public class ReqBPutKey
    {
        [ValidateNever]
        [JsonPropertyName("key")]
        public Key? key { get; set; }

        [JsonPropertyName("custIdent")]
        public CustIdent? custIdent { get; set; }

        [ValidateNever]
        [JsonPropertyName("vaultInsc")]
        public VaultInsc? vaultInsc { get; set; }


        [JsonPropertyName("effDtKey")]
        public EffDtKey? effDtKey { get; set; }


        [JsonPropertyName("merchantId")]
        public string? merchantId { get; set; }
        
        [JsonPropertyName("keyObservation")]
        public string? keyObservation { get; set; }

    }
}
