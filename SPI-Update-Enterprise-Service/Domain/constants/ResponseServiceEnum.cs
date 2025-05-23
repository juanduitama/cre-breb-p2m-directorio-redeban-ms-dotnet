using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPI_Update_Enterprise_Service.Domain.constants
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

        /// <summary>
        /// BODY
        /// </summary>
        INVALID_DT_REQUEST,
        INVALID_ENTERPRISE_TYPE,


        INVALID_TYPE_ID,
        INVALID_ID,


        INVALID_DT_MODIFY,
        INVALID_VAULT_NAME,
        
        INVALID_ADDRESS,
        INVALID_CODE_DANE,
        INVALID_COUNTRY,
        INVALID_NAME_RL,
        INVALID_MOBILE_NUMBER,
        INVALID_TYPE_IDRL,
        INVALID_IDRL,
        INVALID_NAME_COM,
        INVALID_ADDRESS_COM,
        INVALID_CODE_DANE_COM,
        INVALID_COUNTRY_COM,


        INVALID_KEY_ID,

        DIFFERENT_ID,
        DIFFERENT_TYPE,
        DIFFERENT_ID_RL,
        DIFFERENT_TYPE_RL,


        /// <summary>
        /// Errores controlados de servicios
        /// </summary>
        NOT_NULL,
        NOT_FOUND_KEY,
        CONNECTION_OS,
        SERVICE_RED_ERROR,
        SERVICE_HTTP_ERROR,
        SERVICE_S3_ERROR,
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

                ResponseServiceEnums.INVALID_IP_ORIGIN => "400",
                ResponseServiceEnums.INVALID_UUID => "400",
                ResponseServiceEnums.INVALID_TIMESTAMP => "400",
                ResponseServiceEnums.INVALID_SYSTEM_ID => "400",
                ResponseServiceEnums.INVALID_DT_REQUEST => "400",
                ResponseServiceEnums.INVALID_ENTERPRISE_TYPE => "400",
                ResponseServiceEnums.INVALID_TYPE_ID => "400",
                ResponseServiceEnums.INVALID_ID => "400",
                ResponseServiceEnums.INVALID_ADDRESS => "400",
                ResponseServiceEnums.INVALID_CODE_DANE => "400",
                ResponseServiceEnums.INVALID_COUNTRY => "400",
                ResponseServiceEnums.INVALID_TYPE_IDRL => "400",
                ResponseServiceEnums.INVALID_IDRL => "400",
                ResponseServiceEnums.INVALID_NAME_RL => "400",
                ResponseServiceEnums.INVALID_NAME_COM => "400",
                ResponseServiceEnums.INVALID_ADDRESS_COM => "400",
                ResponseServiceEnums.INVALID_CODE_DANE_COM => "400",
                ResponseServiceEnums.INVALID_COUNTRY_COM => "400",
                ResponseServiceEnums.INVALID_KEY_ID => "400",
                ResponseServiceEnums.DIFFERENT_ID => "400",
                ResponseServiceEnums.DIFFERENT_TYPE => "400",
                ResponseServiceEnums.NOT_FOUND_KEY => "206",
                ResponseServiceEnums.CONNECTION_OS => "500",
                ResponseServiceEnums.SERVICE_RED_ERROR => "206",
                ResponseServiceEnums.SERVICE_HTTP_ERROR => "500",
                ResponseServiceEnums.SERVICE_S3_ERROR => "500",
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
                ResponseServiceEnums.INVALID_IP_ORIGIN => "[headers.ipOrigin] son cabeceras obligatorias",
                ResponseServiceEnums.INVALID_UUID => "[headers.uuid] son cabeceras obligatorias",
                ResponseServiceEnums.INVALID_TIMESTAMP => "[headers.timeStamps] no cumple con el formato de fecha establecido",
                ResponseServiceEnums.INVALID_SYSTEM_ID => "[headers.systemId] son cabeceras obligatorias",
                ResponseServiceEnums.INVALID_DT_REQUEST => "[requestDateTime] no cumple con el formato de fecha establecido",
                ResponseServiceEnums.INVALID_ENTERPRISE_TYPE => "[entInfo.enterpriseType] no cumple con el formato de fecha establecido",
                ResponseServiceEnums.INVALID_TYPE_ID => "[entInfo.entIdent.entIdentType] no cumple con los valores de tipo de documentos.",
                ResponseServiceEnums.INVALID_ID => "[entInfo.entIdent.entIdentId] no cumple con el formato establecido o supera la longitud permitida.",
                ResponseServiceEnums.INVALID_CODE_DANE => "[entInfo.entContact.daneCode] no cumple con el formato establecido o supera la longitud permitida",
                ResponseServiceEnums.INVALID_COUNTRY => "[entInfo.entContact.country] no cumple con los valores de codigo de pais. ",
                ResponseServiceEnums.INVALID_ADDRESS => "[entInfo.entContact.address] es un campo obligatorio.",
                ResponseServiceEnums.INVALID_TYPE_IDRL => "[entInfo.entIdent.entIdentType] no cumple con los valores de tipo de documentos.",
                ResponseServiceEnums.INVALID_IDRL => "[entInfo.entIdent.entIdentId] no cumple con el formato establecido o supera la longitud permitida.",
                ResponseServiceEnums.INVALID_NAME_RL => "[legalInfo.nameRl] no comple con el formato establecido o supera la longitud permitida.",
                ResponseServiceEnums.INVALID_NAME_COM => "[commerce.nameCommerce] no cumple con el formato establecido o supera la longitud permitida.",
                ResponseServiceEnums.INVALID_CODE_DANE_COM => "[commerce.entCommerceContact.daneCode] no cumple con el formato establecido o supera la longitud permitida",
                ResponseServiceEnums.INVALID_COUNTRY_COM => "[commerce.entCommerceContact.country] no cumple con los valores de codigo de pais. ",
                ResponseServiceEnums.INVALID_ADDRESS_COM => "[commerce.entCommerceContact.address] es un campo obligatorio.",
                ResponseServiceEnums.INVALID_KEY_ID => "[key.keyId] la llave no cumple los valores permitidos o el formato requerido.",
                ResponseServiceEnums.DIFFERENT_ID => "El número de identificación es diferente al que se encuentra regsitrado",
                ResponseServiceEnums.DIFFERENT_TYPE => "El tipo de documento es difernete al que se encuentra registrado",
                ResponseServiceEnums.NOT_FOUND_KEY => "La llave que se quiere modificar no se encuentra registrada",
                ResponseServiceEnums.CONNECTION_OS => "No se generó la conexión con open search",
                ResponseServiceEnums.SERVICE_RED_ERROR => "Error en el servicio de redeban.",
                ResponseServiceEnums.SERVICE_HTTP_ERROR => "Error al momento de crear la conexión http.",
                ResponseServiceEnums.SERVICE_S3_ERROR => "Error al momento de consumir el servicio de S3.",
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
                ResponseServiceEnums.INVALID_IP_ORIGIN => 400,
                ResponseServiceEnums.INVALID_UUID => 400,
                ResponseServiceEnums.INVALID_TIMESTAMP => 400,
                ResponseServiceEnums.INVALID_SYSTEM_ID => 400,
                ResponseServiceEnums.INVALID_DT_REQUEST => 400,
                ResponseServiceEnums.INVALID_ENTERPRISE_TYPE => 400,
                ResponseServiceEnums.INVALID_TYPE_ID => 400,
                ResponseServiceEnums.INVALID_ID => 400,
                ResponseServiceEnums.INVALID_ADDRESS => 400,
                ResponseServiceEnums.INVALID_CODE_DANE => 400,
                ResponseServiceEnums.INVALID_COUNTRY => 400,
                ResponseServiceEnums.INVALID_TYPE_IDRL => 400,
                ResponseServiceEnums.INVALID_IDRL => 400,
                ResponseServiceEnums.INVALID_NAME_RL => 400,
                ResponseServiceEnums.INVALID_NAME_COM => 400,
                ResponseServiceEnums.INVALID_ADDRESS_COM => 400,
                ResponseServiceEnums.INVALID_CODE_DANE_COM => 400,
                ResponseServiceEnums.INVALID_COUNTRY_COM => 400,
                ResponseServiceEnums.INVALID_KEY_ID => 400,
                ResponseServiceEnums.DIFFERENT_ID => 400,
                ResponseServiceEnums.DIFFERENT_TYPE => 400,
                ResponseServiceEnums.NOT_FOUND_KEY => 206,
                ResponseServiceEnums.CONNECTION_OS => 500,
                ResponseServiceEnums.SERVICE_RED_ERROR => 206,
                ResponseServiceEnums.SERVICE_HTTP_ERROR => 500,
                ResponseServiceEnums.SERVICE_S3_ERROR => 500,
                ResponseServiceEnums.SERVICE_INTERNAL_ERROR => 500,
                _ => throw new ArgumentOutOfRangeException(nameof(responseService))
            };
        }

        
    }
}