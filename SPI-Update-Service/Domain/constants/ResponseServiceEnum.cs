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
        INVALID_KEY_STATUS,
        INVALID_DT_MODIFY,
        INVALID_VAULT_NAME,
        DIFFERENT_ID,
        DIFFERENT_TYPE,
        SERVICE_ACCOUNT_ERROR,
       
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
                ResponseServiceEnum.INVALID_KEY_STATUS => "400",
                ResponseServiceEnum.INVALID_DT_MODIFY => "400",
                ResponseServiceEnum.INVALID_VAULT_NAME => "400",
                ResponseServiceEnum.DIFFERENT_ID => "400",
                ResponseServiceEnum.DIFFERENT_TYPE => "400",
                ResponseServiceEnum.SERVICE_ACCOUNT_ERROR => "400",
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
                ResponseServiceEnum.INVALID_DT_MODIFY => "[effDtKey.effDtModify] no cumple con el formato permitido.",
                ResponseServiceEnum.INVALID_VAULT_NAME => "[vaultInsc.vaultName] no cumple con los valores del vault name.",
                ResponseServiceEnum.DIFFERENT_ID => "El número de identificación es diferente al que se encuentra regsitrado",
                ResponseServiceEnum.DIFFERENT_TYPE => "El tipo de documento es difernete al que se encuentra registrado",
                ResponseServiceEnum.SERVICE_ACCOUNT_ERROR => "No se pudo modificar el producto.",
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
                ResponseServiceEnum.INVALID_KEY_STATUS => 400,
                ResponseServiceEnum.INVALID_DT_MODIFY => 400,
                ResponseServiceEnum.INVALID_VAULT_NAME => 400,
                ResponseServiceEnum.DIFFERENT_ID => 400,
                ResponseServiceEnum.DIFFERENT_TYPE => 400,
                ResponseServiceEnum.SERVICE_ACCOUNT_ERROR => 400,
                ResponseServiceEnum.INVALID_KEY_ID => 400,
                _ => throw new ArgumentOutOfRangeException(nameof(responseService))
            };
        }

        
    }
}