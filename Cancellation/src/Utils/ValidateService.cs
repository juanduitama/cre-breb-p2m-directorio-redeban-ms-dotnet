using System.Text.RegularExpressions;
using SPI_Cancellation_Service.Domain.constants;
using SPI_Cancellation_Service.Domain.models.delete;
using SPI_Cancellation_Service.Domain.models.openSearchModel;
using SPI_Cancellation_Service.Utils.util;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SPI_Cancellation_Service.Utils
{
    public class ValidateService
    {
        /// <summary>
        /// Validación de los headers del request
        /// </summary>
        /// <param name="deleteHeaders"></param>
        /// <returns></returns>
        /// <exception cref="SerfiException"></exception>
        public bool validateHeaders(DeleteHeaders deleteHeaders)
        {
            if (string.IsNullOrEmpty(deleteHeaders.ipOrigin))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_IP_ORIGIN.getErrorCode(), ResponseServiceEnums.INVALID_IP_ORIGIN.getMessage(), ResponseServiceEnums.INVALID_IP_ORIGIN.getHttpCode());
            }
            else if (string.IsNullOrEmpty(deleteHeaders.uuId))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_UUID.getErrorCode(), ResponseServiceEnums.INVALID_UUID.getMessage(), ResponseServiceEnums.INVALID_UUID.getHttpCode());
            }
            else if (!validateDateFormat(deleteHeaders.timeStamps))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_TIMESTAMP.getErrorCode(), ResponseServiceEnums.INVALID_TIMESTAMP.getMessage(), ResponseServiceEnums.INVALID_TIMESTAMP.getHttpCode());
            }
            else if (string.IsNullOrEmpty(deleteHeaders.systemId))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_SYSTEM_ID.getErrorCode(), ResponseServiceEnums.INVALID_SYSTEM_ID.getMessage(), ResponseServiceEnums.INVALID_SYSTEM_ID.getHttpCode());
            }

            return true;
        }

        /// <summary>
        /// Validación del request body
        /// </summary>
        /// <param name="deleteKeyRq"></param>
        /// <returns></returns>
        /// <exception cref="SerfiException"></exception>
        public bool validateServiceDeleteKeyModel(ReqBPutKey deleteKeyRq)
        {
            //Validacion del keyId y keyType
            if (!validateKeyType(deleteKeyRq.key.keyType, deleteKeyRq.key.keyId))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_KEY_TYPE.getErrorCode(), ResponseServiceEnums.INVALID_KEY_TYPE.getMessage(), ResponseServiceEnums.INVALID_KEY_TYPE.getHttpCode());
            }
            //Validacion del keyStatus
            else if (!validateKeyStatus(deleteKeyRq.key.keyStatus))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_KEY_STATUS.getErrorCode(), ResponseServiceEnums.INVALID_KEY_STATUS.getMessage(), ResponseServiceEnums.INVALID_KEY_STATUS.getHttpCode());
            }
            //Validacion del custIdentType
            else if (!validateIdentType(deleteKeyRq.custIdent.custIdentType))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_TYPE_ID.getErrorCode(), ResponseServiceEnums.INVALID_TYPE_ID.getMessage(), ResponseServiceEnums.INVALID_TYPE_ID.getHttpCode());
            }
            //Validacion del custIdentId
            else if (!validateRegex(deleteKeyRq.custIdent.custIdentId, ValidationEnums.IDENT_ID))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_ID.getErrorCode(), ResponseServiceEnums.INVALID_ID.getMessage(), ResponseServiceEnums.INVALID_ID.getHttpCode());
            }
            //Validación del vault name
            else if (!validateVaultName(deleteKeyRq.vaultInsc.vaultName))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_VAULT_NAME.getErrorCode(), ResponseServiceEnums.INVALID_VAULT_NAME.getMessage(), ResponseServiceEnums.INVALID_VAULT_NAME.getHttpCode());
            }
            //Validación del formato de la fecha
            else if (!ValidateDateFormat(deleteKeyRq.effDtKey.effDtModify))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_DT_MODIFY.getErrorCode(), ResponseServiceEnums.INVALID_DT_MODIFY.getMessage(), ResponseServiceEnums.INVALID_DT_MODIFY.getHttpCode());
            }

            //Validacion del estado de la llave
            Console.WriteLine("validacion Exitosa Key Cancellation");
            return true;
        }

        public bool validateIdentType(string identType)
        {

            switch (identType.ToUpper())
            {
                case ValidationEnums.CUST_IDENT_TYPE_CC:
                    return true;
                    break;
                case ValidationEnums.CUST_IDENT_TYPE_CE:
                    return true;
                    break;
                case ValidationEnums.CUST_IDENT_TYPE_NUIP:
                    return true;
                    break;
                case ValidationEnums.CUST_IDENT_TYPE_NIT:
                    return true;
                    break;
                case ValidationEnums.CUST_IDENT_TYPE_PEP:
                    return true;
                    break;
                case ValidationEnums.CUST_IDENT_TYPE_PAS:
                    return true;
                    break;
                case ValidationEnums.CUST_IDENT_TYPE_TDI:
                    return true;
                    break;
                default:
                    return false;
                    break;
            }
            return true;
        }

        public bool validateKeyType(string keyType, string keyId){
            switch (keyType.ToUpper())
            {
                case ValidationEnums.KEY_TYPE_IDENT:
                    if(!validateRegex(keyId, ValidationEnums.KEY_ID_IDENT)){
                        throw new SerfiException(ResponseServiceEnums.INVALID_KEY_ID.getErrorCode(), ResponseServiceEnums.INVALID_KEY_ID.getMessage(), ResponseServiceEnums.INVALID_KEY_ID.getHttpCode());
                    }else{
                        return true;
                    }
                case ValidationEnums.KEY_TYPE_CEL:
                    if(!validateRegex(keyId, ValidationEnums.KEY_ID_CEL)){
                        throw new SerfiException(ResponseServiceEnums.INVALID_KEY_ID.getErrorCode(), ResponseServiceEnums.INVALID_KEY_ID.getMessage(), ResponseServiceEnums.INVALID_KEY_ID.getHttpCode());
                    }
                    else{
                        return true;
                    }
                case ValidationEnums.KEY_TYPE_EMAIL:
                    if(!validateRegex(keyId, ValidationEnums.KEY_ID_EMAIL)){
                        throw new SerfiException(ResponseServiceEnums.INVALID_KEY_ID.getErrorCode(), ResponseServiceEnums.INVALID_KEY_ID.getMessage(), ResponseServiceEnums.INVALID_KEY_ID.getHttpCode());
                    }
                    else{
                        return true;
                    }
                case ValidationEnums.KEY_TYPE_ALIAS:
                    if(!validateRegex(keyId, ValidationEnums.KEY_ID_ALIAS)){
                        throw new SerfiException(ResponseServiceEnums.INVALID_KEY_ID.getErrorCode(), ResponseServiceEnums.INVALID_KEY_ID.getMessage(), ResponseServiceEnums.INVALID_KEY_ID.getHttpCode());
                    }
                    else{
                        return true;
                    }
                case ValidationEnums.KEY_TYPE_MERCH:
                    if(!validateRegex(keyId, ValidationEnums.KEY_ID_MERCH)){
                        throw new SerfiException(ResponseServiceEnums.INVALID_KEY_ID.getErrorCode(), ResponseServiceEnums.INVALID_KEY_ID.getMessage(), ResponseServiceEnums.INVALID_KEY_ID.getHttpCode());
                    }
                    else{
                        return true;
                    }                    
                default:
                    return false;
            }
        }

        public bool validateKeyStatus(string keyStatus) {
            switch (keyStatus.ToUpper()) {
                case ValidationEnums.KEY_ACTIVE_BY_CLIENT_STATUS:
                    return true;                
                case ValidationEnums.KEY_ACTIVE_BY_ENTITY_STATUS:
                    return true;                    
                case ValidationEnums.KEY_BLOCK_BY_CLIENT_STATUS:
                    return true;                
                case ValidationEnums.KEY_BLOCK_BY_ENTITY_STATUS:
                    return true;                
                case ValidationEnums.KEY_CANCEL_STATUS:
                    return true;                    
                default:
                    return false;            
            }
        }

        public bool validateVaultName(string vaultName) {
            switch (vaultName.ToUpper()) {
                case ValidationEnums.VAULT_NAME_RBM:
                    return true;                
                default:
                    return false;                
            }
        }

        public bool ValidateDateFormat(DateTime date)
        {
            try
            {
                string formattedDate = date.ToString(ValidationEnums.DATE_FORMAT);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool validateRegex(string value, string regex)
        {
            if (value != null && !Regex.IsMatch(value, regex)){
                Console.WriteLine("No valido el regex correctamente");
                return false;
            }

            return true;
        }

        public bool validateStatus(string oldKeyStatus)
        {
            if (oldKeyStatus == ValidationEnums.KEY_ACTIVE_BY_CLIENT_STATUS ||
                oldKeyStatus == ValidationEnums.KEY_ACTIVE_BY_ENTITY_STATUS)
            {
                return true;
            }
            return false;
        }

        public bool validateSameId(ReqBPutKey request, OSDefinitive opSearchEntity)
        {
            if (request.key.keyType == opSearchEntity.key.keyType 
                && request.key.keyId == opSearchEntity.key.keyId)
            {
                return true;
            }
            return false;
        }

        public bool validateSameIdType(ReqBPutKey request, OSDefinitive opSearchEntity)
        {
            if (request.key.keyType == opSearchEntity.key.keyType 
                && request.key.keyId == opSearchEntity.key.keyId)
            {
                return true;
            }
            return false;
        }

        public bool validateDateFormat(string dateString)
        {
            return DateTime.TryParseExact(
                dateString,
                ValidationEnums.DATE_HEADER_FORMAT,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out _);
        }

        public void validateOSEntity(ReqBPutKey request, OSDefinitive opSearchEntity){
            if (opSearchEntity == null){
               throw new SerfiException(ResponseServiceEnums.NOT_FOUND_KEY.getErrorCode(), ResponseServiceEnums.NOT_FOUND_KEY.getMessage(), ResponseServiceEnums.NOT_FOUND_KEY.getHttpCode());
            }else if(!validateStatus(opSearchEntity.key.keyStatus)){
                throw new SerfiException(ResponseServiceEnums.INVALID_KEY_STATUS.getErrorCode(), ResponseServiceEnums.INVALID_KEY_STATUS.getMessage(), ResponseServiceEnums.INVALID_KEY_STATUS.getHttpCode());
            }else if (!validateSameId(request,opSearchEntity)){
                throw new SerfiException(ResponseServiceEnums.DIFFERENT_ID.getErrorCode(), ResponseServiceEnums.DIFFERENT_ID.getMessage(), ResponseServiceEnums.DIFFERENT_ID.getHttpCode());
            }else if(!validateSameIdType(request,opSearchEntity)){
                throw new SerfiException(ResponseServiceEnums.DIFFERENT_TYPE.getErrorCode(), ResponseServiceEnums.DIFFERENT_TYPE.getMessage(), ResponseServiceEnums.DIFFERENT_TYPE.getHttpCode());
            }
        }

    }


}
