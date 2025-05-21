using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPI_Cancellation_Service.Domain.constants
{
    /// <summary>
    /// ResponseServiceEnum - Enum que contiene la información necesaria
    /// para las respuestas de la lambda.
    /// </summary>
    public enum ResponseServiceEnums
    {
        /// <summary>
        /// Constante de error en caso de que se presente un fallo al intentar operación sobre DynamoDB.
        /// </summary>

        ///HEADERS
        ///
        INVALID_IP_ORIGIN,
        INVALID_UUID,
        INVALID_TIMESTAMP,
        INVALID_SYSTEM_ID,
        ///BODY
        ///
        NOT_FOUND_KEY,
        CONNECTION_OS,
        INVALID_KEY_TYPE,
        INVALID_KEY_ID,
        INVALID_KEY_STATUS,
        INVALID_TYPE_ID,
        INVALID_ID,
        INVALID_DT_MODIFY,
        INVALID_VAULT_NAME,
        DIFFERENT_ID,
        DIFFERENT_TYPE,
        SERVICE_RED_ERROR,
        SERVICE_INTERNAL_ERROR
        

    }

    /// <summary>
    /// Extensiones para ResponseServiceEnum
    /// </summary>
    public static class ResponseServiceEnumExtensions
    {
        /// <summary>
        /// Obtiene el código de estado HTTP
        /// </summary>
        public static string getErrorCode(this ResponseServiceEnums responseService)
        {
            return responseService switch
            {
                ResponseServiceEnums.NOT_FOUND_KEY => "206",
                ResponseServiceEnums.CONNECTION_OS => "500",             
                ResponseServiceEnums.INVALID_IP_ORIGIN => "400",
                ResponseServiceEnums.INVALID_UUID => "400",
                ResponseServiceEnums.INVALID_TIMESTAMP => "400",
                ResponseServiceEnums.INVALID_SYSTEM_ID => "400",
                ResponseServiceEnums.INVALID_KEY_TYPE => "400",
                ResponseServiceEnums.INVALID_KEY_ID => "400",
                ResponseServiceEnums.INVALID_KEY_STATUS => "400",
                ResponseServiceEnums.INVALID_TYPE_ID => "400",
                ResponseServiceEnums.INVALID_ID => "400",
                ResponseServiceEnums.INVALID_VAULT_NAME => "400",
                ResponseServiceEnums.INVALID_DT_MODIFY => "400",
                ResponseServiceEnums.DIFFERENT_ID => "400",
                ResponseServiceEnums.DIFFERENT_TYPE => "400",
                ResponseServiceEnums.SERVICE_RED_ERROR => "206",
                ResponseServiceEnums.SERVICE_INTERNAL_ERROR => "500",
                _ => throw new ArgumentOutOfRangeException(nameof(responseService))
            };
        }

        /// <summary>
        /// Obtiene el código de estado del servidor
        /// </summary>
        public static string getMessage(this ResponseServiceEnums responseService)
        {
            return responseService switch
            {
                ResponseServiceEnums.NOT_FOUND_KEY => "La llave que se quiere modificar no se encuentra registrada",
                ResponseServiceEnums.CONNECTION_OS => "No se generó la conexión con open search",
                ResponseServiceEnums.INVALID_IP_ORIGIN => "[headers.ipOrigin] son cabeceras obligatorias",
                ResponseServiceEnums.INVALID_UUID => "[headers.uuid] son cabeceras obligatorias",
                ResponseServiceEnums.INVALID_TIMESTAMP => "[headers.] no cumple con el formato de fecha establecido",
                ResponseServiceEnums.INVALID_SYSTEM_ID => "[headers.systemId] son cabeceras obligatorias",
                ResponseServiceEnums.INVALID_KEY_ID => "[key.keyId] la llave no cumple los valores permitidos o el formato requerido.",
                ResponseServiceEnums.INVALID_KEY_TYPE => "[key.keyType] no cumple con los valores de tipo de llave permitidos o el formato requerido.",
                ResponseServiceEnums.INVALID_KEY_STATUS => "[key.keyStatus] no cumple con los valores del estado de la llave permitidos o el formato requerido",
                ResponseServiceEnums.INVALID_TYPE_ID => "[custIdent.custIdentType] no cumple con los valores de tipo de documentos.",
                ResponseServiceEnums.INVALID_ID => "[custIdent.custIdentId] no cumple con el formato establecido o supera la longitud permitida.",
                ResponseServiceEnums.INVALID_VAULT_NAME => "[vaultInsc.vaultName] no cumple con los valores del vault name.",
                ResponseServiceEnums.INVALID_DT_MODIFY => "[effDtKey.effDtModify] no cumple con el formato permitido.",
                ResponseServiceEnums.DIFFERENT_ID => "El número de identificación es diferente al que se encuentra regsitrado",
                ResponseServiceEnums.DIFFERENT_TYPE => "El tipo de documento es difernete al que se encuentra registrado",
                ResponseServiceEnums.SERVICE_RED_ERROR => "Error en el servicio de redeban.",
                ResponseServiceEnums.SERVICE_INTERNAL_ERROR => "Error interno del servidor",
                _ => throw new ArgumentOutOfRangeException(nameof(responseService))
            };
        }

        /// <summary>
        /// Obtiene la severidad del error
        /// </summary>
        public static int getHttpCode(this ResponseServiceEnums responseService)
        {
            return responseService switch
            {
                ResponseServiceEnums.NOT_FOUND_KEY => 206,
                ResponseServiceEnums.CONNECTION_OS => 500,
                ResponseServiceEnums.INVALID_IP_ORIGIN => 400,
                ResponseServiceEnums.INVALID_UUID => 400,
                ResponseServiceEnums.INVALID_TIMESTAMP => 400,
                ResponseServiceEnums.INVALID_SYSTEM_ID => 400,
                ResponseServiceEnums.INVALID_KEY_TYPE => 400,
                ResponseServiceEnums.INVALID_KEY_STATUS => 400,
                ResponseServiceEnums.INVALID_TYPE_ID => 400,
                ResponseServiceEnums.INVALID_ID => 400,
                ResponseServiceEnums.INVALID_VAULT_NAME => 400,
                ResponseServiceEnums.INVALID_DT_MODIFY => 400,
                ResponseServiceEnums.DIFFERENT_ID => 400,
                ResponseServiceEnums.DIFFERENT_TYPE => 400,
                ResponseServiceEnums.SERVICE_RED_ERROR => 206,
                ResponseServiceEnums.SERVICE_INTERNAL_ERROR => 500,
                _ => throw new ArgumentOutOfRangeException(nameof(responseService))
            };
        }

        
    }
}