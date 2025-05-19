using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace domain.models
{
    public class Key
    {
        /**
         * Tipo de llave seleccionada por el cliente para identificarse en el Sistema de pago de bajo valor inmediato.
         * | MERCHANTID: Identificador de codigo único
         * | USERIDENTIFICATION: Documento de identidad
         * |MSISDN: Número de celular
         * | EMAIL: Correo electrónico
         * | ALIAS: Identificador alfanumérico |
         */
        [JsonPropertyName("keyType")]
        public string keyType { get; set; }

        /**
         * Valor de la llave
         */
        [JsonPropertyName("keyId")]
        public string keyId { get; set; }

        /**
         * Estado de la llave | ACTIVA: Activa | BLOQUEADA: Bloqueada
         * | ON_HOLD: Suspendida por proceso de portabilidad | CANCELADA: Cancelada
         */
        [JsonPropertyName("keyStatus")]
        public string keyStatus { get; set; }

        [JsonPropertyName("oldKeyType")]
        public string oldKeyType { get; set; }


        [JsonPropertyName("oldKeyId")]
        public string oldKeyId { get; set; }

        [JsonPropertyName("oldKeyStatus")]
        public string oldKeyStatus { get; set; }

        [JsonPropertyName("newKeyType")]
        public string newKeyType { get; set; }

        [JsonPropertyName("newKeyId")]
        public string newKeyId { get; set; }

        [JsonPropertyName("newKeyStatus")]
        public string newKeyStatus { get; set; }

    }
}
