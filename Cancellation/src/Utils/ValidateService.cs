using System.Text.RegularExpressions;
using SPI_Cancellation_Service.Domain.constants;
using SPI_Cancellation_Service.Domain.models.delete;
using SPI_Cancellation_Service.Domain.models.openSearchModel;
using SPI_Cancellation_Service.Utils.util;

namespace SPI_Cancellation_Service.Utils
{
    public class ValidateService
    {
        
        public bool validateServiceDeleteKeyModel(ReqBPutKey deleteKeyRq) 
        {

            
            if (!validateKeyStatus(deleteKeyRq.key.keyStatus))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_KEY_STATUS.getErrorCode(), ResponseServiceEnum.INVALID_KEY_STATUS.getMessage(), ResponseServiceEnum.INVALID_KEY_STATUS.getHttpCode());
            }
            //Validación del vault name
            else if (!validateVaultName(deleteKeyRq.vaultInsc.vaultName))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_VAULT_NAME.getErrorCode(), ResponseServiceEnum.INVALID_VAULT_NAME.getMessage(), ResponseServiceEnum.INVALID_VAULT_NAME.getHttpCode());
            }
            //Validación del formato de la fecha
            else if (!validateDateFormat(deleteKeyRq.effDtKey.effDtModify))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_DT_MODIFY.getErrorCode(), ResponseServiceEnum.INVALID_DT_MODIFY.getMessage(), ResponseServiceEnum.INVALID_DT_MODIFY.getHttpCode());
            }

            //Validacion del estado de la llave
            Console.WriteLine("validacion Exitosa Key Update");
            return true;
        }        

        public bool validateKeyType(string keyType, string keyId){
            switch (keyType)
            {
                case ValidationEnums.KEY_TYPE_IDENT:
                    if(!validateRegex(keyId, ValidationEnums.KEY_ID_IDENT)){
                        throw new SerfiException(ResponseServiceEnum.INVALID_KEY_ID.getErrorCode(), ResponseServiceEnum.INVALID_KEY_ID.getMessage(), ResponseServiceEnum.INVALID_KEY_ID.getHttpCode());
                    }else{
                        return true;
                    }
                case ValidationEnums.KEY_TYPE_CEL:
                    if(!validateRegex(keyId, ValidationEnums.KEY_ID_CEL)){
                        throw new SerfiException(ResponseServiceEnum.INVALID_KEY_ID.getErrorCode(), ResponseServiceEnum.INVALID_KEY_ID.getMessage(), ResponseServiceEnum.INVALID_KEY_ID.getHttpCode());
                    }
                    else{
                        return true;
                    }
                case ValidationEnums.KEY_TYPE_EMAIL:
                    if(!validateRegex(keyId, ValidationEnums.KEY_ID_EMAIL)){
                        throw new SerfiException(ResponseServiceEnum.INVALID_KEY_ID.getErrorCode(), ResponseServiceEnum.INVALID_KEY_ID.getMessage(), ResponseServiceEnum.INVALID_KEY_ID.getHttpCode());
                    }
                    else{
                        return true;
                    }
                case ValidationEnums.KEY_TYPE_ALIAS:
                    if(!validateRegex(keyId, ValidationEnums.KEY_ID_ALIAS)){
                        throw new SerfiException(ResponseServiceEnum.INVALID_KEY_ID.getErrorCode(), ResponseServiceEnum.INVALID_KEY_ID.getMessage(), ResponseServiceEnum.INVALID_KEY_ID.getHttpCode());
                    }
                    else{
                        return true;
                    }
                case ValidationEnums.KEY_TYPE_MERCH:
                    if(!validateRegex(keyId, ValidationEnums.KEY_ID_MERCH)){
                        throw new SerfiException(ResponseServiceEnum.INVALID_KEY_ID.getErrorCode(), ResponseServiceEnum.INVALID_KEY_ID.getMessage(), ResponseServiceEnum.INVALID_KEY_ID.getHttpCode());
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
            switch (vaultName) {
                case ValidationEnums.VAULT_NAME_RBM:
                    return true;                
                default:
                    return false;                
            }
        }

        public bool validateDateFormat(DateTime date) {
            return DateTime.SpecifyKind(date, DateTimeKind.Utc)
                .ToString(ValidationEnums.DATE_FORMAT)
                .EndsWith("Z");
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
            if (oldKeyStatus == ValidationEnums.KEY_ACTIVE_BY_CLIENT_STATUS || oldKeyStatus == ValidationEnums.KEY_ACTIVE_BY_ENTITY_STATUS)
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
            if (request.key.keyType == opSearchEntity.key.keyType && request.key.keyId == opSearchEntity.key.keyId)
            {
                return true;
            }
            return false;
        }


        public void validateOSEntity(ReqBPutKey request, OSDefinitive opSearchEntity){
            if (opSearchEntity == null){
               throw new SerfiException(ResponseServiceEnum.NOT_FOUND_KEY.getErrorCode(), ResponseServiceEnum.NOT_FOUND_KEY.getMessage(), ResponseServiceEnum.NOT_FOUND_KEY.getHttpCode());
            }else if(!validateStatus(opSearchEntity.key.keyStatus)){
                throw new SerfiException(ResponseServiceEnum.INVALID_KEY_STATUS.getErrorCode(), ResponseServiceEnum.INVALID_KEY_STATUS.getMessage(), ResponseServiceEnum.INVALID_KEY_STATUS.getHttpCode());
            }else if (!validateSameId(request,opSearchEntity)){
                throw new SerfiException(ResponseServiceEnum.DIFFERENT_ID.getErrorCode(), ResponseServiceEnum.DIFFERENT_ID.getMessage(), ResponseServiceEnum.DIFFERENT_ID.getHttpCode());
            }else if(!validateSameIdType(request,opSearchEntity)){
                throw new SerfiException(ResponseServiceEnum.DIFFERENT_TYPE.getErrorCode(), ResponseServiceEnum.DIFFERENT_TYPE.getMessage(), ResponseServiceEnum.DIFFERENT_TYPE.getHttpCode());
            }
        }

    }


}
