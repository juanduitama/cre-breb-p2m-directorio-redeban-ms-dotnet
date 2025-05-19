using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SPI_Update_Service.Domain.models.redeban
{
        public class Person
        {

            /**
            * Primer nombre del cliente
            */
            [Required]
            [JsonPropertyName("FirstName")]
            public string? firstName { get; set; }

            /**
            * Segundo nombre del cliente
            */
            [JsonPropertyName("MiddleName")]
            public string? middleName { get; set; }

            /**
            * Primer apellido del cliente
            */
            [Required]
            [JsonPropertyName("FirstSurName")]
            public string? firstSurName { get; set; }

            /**
            * Segundo apellido del cliente
            */
            [JsonPropertyName("MiddleSurName")]
            public string? middleSurName { get; set; }

            /**
             * Instancia de la clase PersonContact
             */
            [Required]
            [JsonPropertyName("PersonContact")]
            public PersonContact? personContact { get; set; }

            /**
            * Tipo de documento (CC,CE, NUIP, PPT, NIT,
            * PEP, PAS, TDI, OTR)
            */
            [Required]
            [JsonPropertyName("DocumentType")]
            public string? documentType { get; set; }

            /**
            * Numero de documento
            */
            [Required]
            [JsonPropertyName("DocumentNumber")]
            public string? documentNumber { get; set; }
        }
    }
