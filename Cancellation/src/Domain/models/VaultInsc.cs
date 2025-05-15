using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SPI_Cancellation_Service.Domain.models
{
    public class VaultInsc
    {
        
        [JsonPropertyName("vaultName")]
        public string? vaultName { get; set; }
    }
}
