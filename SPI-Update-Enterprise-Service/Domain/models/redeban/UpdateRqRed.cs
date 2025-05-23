using System.Text.Json.Serialization;

namespace SPI_Update_Enterprise_Service.Domain.models.redeban
{
    public class UpdateRqRed
    {
        [JsonPropertyName("RequestDateTime")]
        public string? requestDateTime { get; set; }

        [JsonPropertyName("DocumentNumber")]
        public string? documentNumber { get; set; }

        [JsonPropertyName("NameEnterprise")]
        public string? nameEnterprise { get; set; }

        [JsonPropertyName("LegalRepresentative")]
        public LegalRepresentative? legalRepresentative { get; set; }

        [JsonPropertyName("EnterpriseContact")]
        public EnterpriseContact? enterpriseContact { get; set; }

        [JsonPropertyName("Commerce")]
        public CommerceRed? commerce { get; set; }

    }
}
