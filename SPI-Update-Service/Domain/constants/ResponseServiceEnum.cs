using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.constants
{
    /// <summary>
    /// ResponseServiceEnum - Enum que contiene la información necesaria
    /// para las respuestas de la lambda.
    /// </summary>
    public enum ResponseServiceEnum
    {
        /// <summary>
        /// Constante de error en caso de que se presente un fallo al intentar operación sobre DynamoDB.
        /// </summary>
        NOT_FOUND_KEY,  
        INVALID_IPORIGIN,
        INVALID_UUID,
        INVALID_TIMESTAMP,
        INVALID_SYSTEMID,
        INVALID_ACCTYPE,
        INVALID_ACCTID,
        INVALID_OLD_ACCTYPE,
        INVALID_OLD_ACCTID,
        INVALID_NEW_ACCTYPE,
        INVALID_NEW_ACCTID,
        INVALID_TYPE_PERSON,
        INVALID_TYPE_ID,
        INVALID_ID,
        INVALID_KEY_TYPE,
        INVALID_KEY_ID,
        INVALID_OLD_KEY_ID,
        INVALID_OLD_KEY_TYPE,
        INVALID_NEW_KEY_ID,
        INVALID_NEW_KEY_TYPE,
        INVALID_DT_MODIFY,
        INVALID_VAULT_NAME,
        DIFFERENT_ID,
        DIFFERENT_TYPE,
        SERVICE_ACCOUNT_ERROR,
        SERVICE_KEY_ERROR,
        INVALID_FIRST_NAME,
        INVALID_SECOND_NAME,
        INVALID_LAST_NAME,
        INVALID_SECOND_LAST_NAME,
        INVALID_CEL_NUMBER,
        ERROR_CERTIFICATE,
        ERROR_S3,

        DYNAMO_ERROR,
        DYNAMO_CLIENT_ERROR,
       
    }

    /// <summary>
    /// Extensiones para ResponseServiceEnum
    /// </summary>
    public static class ResponseServiceEnumExtensions
    {
        /// <summary>
        /// Obtiene el código de estado HTTP
        /// </summary>
        public static string getErrorCode(this ResponseServiceEnum responseService)
        {
            return responseService switch
            {
                ResponseServiceEnum.NOT_FOUND_KEY => "206",
                ResponseServiceEnum.INVALID_IPORIGIN => "400",
                ResponseServiceEnum.INVALID_UUID => "400",
                ResponseServiceEnum.INVALID_TIMESTAMP => "400",
                ResponseServiceEnum.INVALID_SYSTEMID => "400",
                ResponseServiceEnum.INVALID_ACCTYPE => "400",
                ResponseServiceEnum.INVALID_ACCTID => "400",
                ResponseServiceEnum.INVALID_OLD_ACCTYPE => "400",
                ResponseServiceEnum.INVALID_OLD_ACCTID => "400",
                ResponseServiceEnum.INVALID_NEW_ACCTYPE => "400",
                ResponseServiceEnum.INVALID_NEW_ACCTID => "400",
                ResponseServiceEnum.INVALID_TYPE_PERSON => "400",
                ResponseServiceEnum.INVALID_TYPE_ID => "400",
                ResponseServiceEnum.INVALID_ID => "400",
                ResponseServiceEnum.INVALID_KEY_TYPE => "400",
                ResponseServiceEnum.INVALID_KEY_ID => "400",
                ResponseServiceEnum.INVALID_OLD_KEY_ID => "400",
                ResponseServiceEnum.INVALID_OLD_KEY_TYPE => "400",
                ResponseServiceEnum.INVALID_NEW_KEY_ID => "400",
                ResponseServiceEnum.INVALID_NEW_KEY_TYPE => "400",
                ResponseServiceEnum.INVALID_DT_MODIFY => "400",
                ResponseServiceEnum.INVALID_VAULT_NAME => "400",
                ResponseServiceEnum.DIFFERENT_ID => "400",
                ResponseServiceEnum.DIFFERENT_TYPE => "400",
                ResponseServiceEnum.SERVICE_ACCOUNT_ERROR => "206",
                ResponseServiceEnum.SERVICE_KEY_ERROR => "206",
                ResponseServiceEnum.INVALID_FIRST_NAME => "400",
                ResponseServiceEnum.INVALID_SECOND_NAME => "400",
                ResponseServiceEnum.INVALID_LAST_NAME => "400",
                ResponseServiceEnum.INVALID_SECOND_LAST_NAME => "400",
                ResponseServiceEnum.INVALID_CEL_NUMBER => "400",
                ResponseServiceEnum.DYNAMO_ERROR => "500",
                ResponseServiceEnum.DYNAMO_CLIENT_ERROR => "500",
                ResponseServiceEnum.ERROR_CERTIFICATE => "500",
                ResponseServiceEnum.ERROR_S3 => "500",
                _ => throw new ArgumentOutOfRangeException(nameof(responseService))
            };
        }

        /// <summary>
        /// Obtiene el código de estado del servidor
        /// </summary>
        public static string getMessage(this ResponseServiceEnum responseService)
        {
            return responseService switch
            {
                ResponseServiceEnum.NOT_FOUND_KEY => "La llave que se quiere modificar no se encuentra registrada",
                ResponseServiceEnum.INVALID_IPORIGIN => "[ipOrigin] no puede estar vacío",
                ResponseServiceEnum.INVALID_UUID => "[uuid] no puede estar vacío",
                ResponseServiceEnum.INVALID_TIMESTAMP => "[timeStamp] no cumple con el formato requerido yyyy-MM-dd'T'HH:mm:ss.fff",
                ResponseServiceEnum.INVALID_SYSTEMID => "[systemId] no puede estar vacío",
                ResponseServiceEnum.INVALID_ACCTYPE => "[AcctInfo.acctType] no corresponde a los tipos de cuenta permitidos.",
                ResponseServiceEnum.INVALID_ACCTID => "[ActtInfo.acctId] no corresponde a los valores permitidos como número de cuenta.",
                ResponseServiceEnum.INVALID_OLD_ACCTYPE => "[ActtInfo.oldAcctType] el tipo de cuenta antiguo no corresponde a los tipos de cuenta permitidos.",
                ResponseServiceEnum.INVALID_OLD_ACCTID => "[ActtInfo.oldAcctId] el número de cuenta antiguo no corresponde a los valores permitidos como número de cuenta.",
                ResponseServiceEnum.INVALID_NEW_ACCTYPE => "[ActtInfo.newAcctType] el tipo de cuenta nueva no corresponde a los tipos de cuenta permitidos.",
                ResponseServiceEnum.INVALID_NEW_ACCTID => "[ActtInfo.newAcctId] el número de cuenta nuevo no corresponde a los valores permitidos como número de cuenta.",
                ResponseServiceEnum.INVALID_TYPE_PERSON => "[custInfo.custType] no cumple con los valores de tipo de personas (PERSON y COMMERCE) y/o no cumplen con los campos obligatorios ",
                ResponseServiceEnum.INVALID_TYPE_ID => "[custInfo.custIdent.custIdentType] no cumple con los valores de tipo de documentos.",
                ResponseServiceEnum.INVALID_ID => "[custInfo.custIdent.custIdentId] no cumple con el formato establecido o supera la longitud permitida.",
                ResponseServiceEnum.INVALID_KEY_ID => "[key.keyId] la llave no cumple los valores permitidos o el formato requerido.",
                ResponseServiceEnum.INVALID_KEY_TYPE => "[key.keyType] no cumple con los valores de tipo de llave permitidos o el form.",
                ResponseServiceEnum.INVALID_OLD_KEY_ID => "[key.oldKeyId] la llave antigua no cumple los valores permitidos o el formato requerido.",
                ResponseServiceEnum.INVALID_OLD_KEY_TYPE => "[key.oldKeyType] no cumple con los valores de tipo de llave antigua permitidos o el formato requerido",
                ResponseServiceEnum.INVALID_NEW_KEY_ID => "[key.newKeyId] la llave nueva no cumple los valores permitidos o el formato requerido.",
                ResponseServiceEnum.INVALID_NEW_KEY_TYPE => "[key.newKewType] no cumple con los valores de tipo de llave nueva permitidos o el formato requerido",
                ResponseServiceEnum.INVALID_DT_MODIFY => "[effDtKey.effDtModify] no cumple con el formato permitido.",
                ResponseServiceEnum.INVALID_VAULT_NAME => "[vaultInsc.vaultName] no cumple con los valores del vault name.",
                ResponseServiceEnum.DIFFERENT_ID => "El número de identificación es diferente al que se encuentra regsitrado",
                ResponseServiceEnum.DIFFERENT_TYPE => "El tipo de documento es difernete al que se encuentra registrado",
                ResponseServiceEnum.SERVICE_ACCOUNT_ERROR => "No se pudo modificar el producto en el DIFE",
                ResponseServiceEnum.SERVICE_KEY_ERROR => "No se pudo modificar la llave en el DIFE",
                ResponseServiceEnum.INVALID_FIRST_NAME => "[custInfo.firstName] el primer nombre no cumple com los parámetros establecidos",
                ResponseServiceEnum.INVALID_SECOND_NAME => "[custInfo.secondName] el seg nombre no cumple com los parámetros establecidos",
                ResponseServiceEnum.INVALID_LAST_NAME => "[custInfo.lastName] el primer apellido no cumple com los parámetros establecidos",
                ResponseServiceEnum.INVALID_SECOND_LAST_NAME => "[custInfo.secondLastName] el segundo apellido no cumple com los parámetros establecidos",
                ResponseServiceEnum.INVALID_CEL_NUMBER => "[custContact.custMobileNumber] el número´telefónico no coincide con los parámetros establecidos",
                ResponseServiceEnum.DYNAMO_ERROR => "Hubo un problema al realizar la operación en Dynamo DB",
                ResponseServiceEnum.DYNAMO_CLIENT_ERROR => "No se pudo realizar la conexión al cliente Dynamo DB",
                ResponseServiceEnum.ERROR_CERTIFICATE => "Error al consumir el certificado",
                ResponseServiceEnum.ERROR_S3 => "Error al realizar conexión en S3",
                _ => throw new ArgumentOutOfRangeException(nameof(responseService))
            };
        }

        /// <summary>
        /// Obtiene la severidad del error
        /// </summary>
        public static int getHttpCode(this ResponseServiceEnum responseService)
        {
            return responseService switch
            {
                ResponseServiceEnum.NOT_FOUND_KEY => 206,
                ResponseServiceEnum.INVALID_IPORIGIN => 400,
                ResponseServiceEnum.INVALID_UUID => 400,
                ResponseServiceEnum.INVALID_TIMESTAMP => 400,
                ResponseServiceEnum.INVALID_SYSTEMID => 400,
                ResponseServiceEnum.INVALID_ACCTYPE => 400,
                ResponseServiceEnum.INVALID_ACCTID => 400,
                ResponseServiceEnum.INVALID_OLD_ACCTYPE => 400,
                ResponseServiceEnum.INVALID_OLD_ACCTID => 400,
                ResponseServiceEnum.INVALID_NEW_ACCTYPE => 400,
                ResponseServiceEnum.INVALID_NEW_ACCTID => 400,
                ResponseServiceEnum.INVALID_TYPE_PERSON => 400,
                ResponseServiceEnum.INVALID_TYPE_ID => 400,
                ResponseServiceEnum.INVALID_ID => 400,
                ResponseServiceEnum.INVALID_KEY_TYPE => 400,
                ResponseServiceEnum.INVALID_OLD_KEY_ID => 400,
                ResponseServiceEnum.INVALID_OLD_KEY_TYPE => 400,
                ResponseServiceEnum.INVALID_NEW_KEY_ID => 400,
                ResponseServiceEnum.INVALID_NEW_KEY_TYPE => 400,
                ResponseServiceEnum.INVALID_DT_MODIFY => 400,
                ResponseServiceEnum.INVALID_VAULT_NAME => 400,
                ResponseServiceEnum.DIFFERENT_ID => 400,
                ResponseServiceEnum.DIFFERENT_TYPE => 400,
                ResponseServiceEnum.SERVICE_ACCOUNT_ERROR => 400,
                ResponseServiceEnum.SERVICE_KEY_ERROR => 400,
                ResponseServiceEnum.INVALID_KEY_ID => 400,
                ResponseServiceEnum.INVALID_FIRST_NAME => 400,
                ResponseServiceEnum.INVALID_SECOND_NAME => 400,
                ResponseServiceEnum.INVALID_LAST_NAME => 400,
                ResponseServiceEnum.INVALID_SECOND_LAST_NAME => 400,
                ResponseServiceEnum.INVALID_CEL_NUMBER => 400,
                ResponseServiceEnum.DYNAMO_ERROR => 500,
                ResponseServiceEnum.DYNAMO_CLIENT_ERROR => 500,
                ResponseServiceEnum.ERROR_CERTIFICATE => 500,
                ResponseServiceEnum.ERROR_S3 => 500,
                _ => throw new ArgumentOutOfRangeException(nameof(responseService))
            };
        }
    }
}