using System.Text.RegularExpressions;
using Nager.Country;
using SPI_Update_Enterprise_Service.Domain.constants;
using SPI_Update_Enterprise_Service.Domain.models;
using SPI_Update_Enterprise_Service.Domain.models.redeban;
using SPI_Update_Enterprise_Service.Domain.models.updateEnterprise;
using SPI_Update_Enterprise_Service.Utils.util;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SPI_Update_Enterprise_Service.Utils
{
    public class ValidateService
    {
        /// <summary>
        /// Validación de los headers del request
        /// </summary>
        /// <param name="deleteHeaders"></param>
        /// <returns></returns>
        /// <exception cref="SerfiException"></exception>
        public bool validateHeaders(UpdateHeadersEnterprise updateHeadersEnterprise)
        {
            if (string.IsNullOrEmpty(updateHeadersEnterprise.ipOrigin))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_IP_ORIGIN.getErrorCode(), ResponseServiceEnums.INVALID_IP_ORIGIN.getMessage(), ResponseServiceEnums.INVALID_IP_ORIGIN.getHttpCode());
            }
            else if (string.IsNullOrEmpty(updateHeadersEnterprise.uuId))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_UUID.getErrorCode(), ResponseServiceEnums.INVALID_UUID.getMessage(), ResponseServiceEnums.INVALID_UUID.getHttpCode());
            }
            else if (!validateDateFormat(updateHeadersEnterprise.timeStamps))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_TIMESTAMP.getErrorCode(), ResponseServiceEnums.INVALID_TIMESTAMP.getMessage(), ResponseServiceEnums.INVALID_TIMESTAMP.getHttpCode());
            }
            else if (string.IsNullOrEmpty(updateHeadersEnterprise.systemId))
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
        public bool validateServiceBody(ReqBPatchEnterprise reqBPatchEnterprise)
        {
            //Validacion de requestDateTime
            if (!validateDateFormat(reqBPatchEnterprise.requestDateTime))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_DT_REQUEST.getErrorCode(), ResponseServiceEnums.INVALID_DT_REQUEST.getMessage(), ResponseServiceEnums.INVALID_DT_REQUEST.getHttpCode());
            }

            #region Validación del entInfo
            //Validacion de enterpriseType
            else if (!validateTypeEnterprise(reqBPatchEnterprise.entInfo.enterpriseType))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_ENTERPRISE_TYPE.getErrorCode(), ResponseServiceEnums.INVALID_ENTERPRISE_TYPE.getMessage(), ResponseServiceEnums.INVALID_ENTERPRISE_TYPE.getHttpCode());
            }
            //Validacion del entIdent
            else if (!validateIdentType(reqBPatchEnterprise.entInfo.entIdent.entIdentType))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_TYPE_ID.getErrorCode(), ResponseServiceEnums.INVALID_TYPE_ID.getMessage(), ResponseServiceEnums.INVALID_TYPE_ID.getHttpCode());
            }
            else if (!validateRegex(reqBPatchEnterprise.entInfo.entIdent.entIdentId, ValidationEnums.IDENT_ID))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_ID.getErrorCode(), ResponseServiceEnums.INVALID_ID.getMessage(), ResponseServiceEnums.INVALID_ID.getHttpCode());
            }
            //Validacion del entContact
            else if (!validateRegex(reqBPatchEnterprise.entInfo.entContact.daneCode, ValidationEnums.DANE_CODE))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_CODE_DANE.getErrorCode(), ResponseServiceEnums.INVALID_CODE_DANE.getMessage(), ResponseServiceEnums.INVALID_CODE_DANE.getHttpCode());
            }
            else if (!IsValidCountryCode(reqBPatchEnterprise.entInfo.entContact.country))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_COUNTRY.getErrorCode(), ResponseServiceEnums.INVALID_COUNTRY.getMessage(), ResponseServiceEnums.INVALID_COUNTRY.getHttpCode());
            }
            else if (string.IsNullOrWhiteSpace(reqBPatchEnterprise.entInfo.entContact.address))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_ADDRESS.getErrorCode(), ResponseServiceEnums.INVALID_ADDRESS.getMessage(), ResponseServiceEnums.INVALID_ADDRESS.getHttpCode());
            }
            #endregion

            #region Validacion del legalInfo

            //Validacion del legalInfo
            else if (string.IsNullOrWhiteSpace(reqBPatchEnterprise.legalInfo.nameRl))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_NAME_RL.getErrorCode(), ResponseServiceEnums.INVALID_NAME_RL.getMessage(), ResponseServiceEnums.INVALID_NAME_RL.getHttpCode());
            }
            else if (!validateRegex(reqBPatchEnterprise.legalInfo.mobileNumber, ValidationEnums.DANE_CODE))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_CODE_DANE.getErrorCode(), ResponseServiceEnums.INVALID_CODE_DANE.getMessage(), ResponseServiceEnums.INVALID_CODE_DANE.getHttpCode());
            }
            //Validacion del entIdentRl

            else if (!validateIdentType(reqBPatchEnterprise.legalInfo.entIdentRl.entIdentType))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_TYPE_IDRL.getErrorCode(), ResponseServiceEnums.INVALID_TYPE_IDRL.getMessage(), ResponseServiceEnums.INVALID_TYPE_IDRL.getHttpCode());
            }
            else if (!validateRegex(reqBPatchEnterprise.legalInfo.entIdentRl.entIdentId, ValidationEnums.IDENT_ID))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_IDRL.getErrorCode(), ResponseServiceEnums.INVALID_IDRL.getMessage(), ResponseServiceEnums.INVALID_IDRL.getHttpCode());
            }

            #endregion

            #region Validación del commerce
            //Validacion del nameCommerce

            else if (string.IsNullOrWhiteSpace(reqBPatchEnterprise.commerce.nameCommerce))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_NAME_COM.getErrorCode(), ResponseServiceEnums.INVALID_NAME_COM.getMessage(), ResponseServiceEnums.INVALID_NAME_COM.getHttpCode());
            }

            //Validacion del entCommerceContact
            else if (!validateRegex(reqBPatchEnterprise.commerce.entCommerceContact.daneCode , ValidationEnums.DANE_CODE))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_CODE_DANE_COM.getErrorCode(), ResponseServiceEnums.INVALID_CODE_DANE_COM.getMessage(), ResponseServiceEnums.INVALID_CODE_DANE_COM.getHttpCode());
            }
            else if (!IsValidCountryCode(reqBPatchEnterprise.commerce.entCommerceContact.country))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_COUNTRY_COM.getErrorCode(), ResponseServiceEnums.INVALID_COUNTRY_COM.getMessage(), ResponseServiceEnums.INVALID_COUNTRY_COM.getHttpCode());
            }
            else if (string.IsNullOrWhiteSpace(reqBPatchEnterprise.commerce.entCommerceContact.address))
            {
                throw new SerfiException(ResponseServiceEnums.INVALID_ADDRESS_COM.getErrorCode(), ResponseServiceEnums.INVALID_ADDRESS_COM.getMessage(), ResponseServiceEnums.INVALID_ADDRESS_COM.getHttpCode());
            }
            #endregion

            //Validacion del merchantId
            else if(!validateKeyType(ValidationEnums.KEY_TYPE_MERCH , reqBPatchEnterprise.merchantId))
            {
                return false;
            }
            Console.WriteLine("validacion Exitosa Key Cancellation");
            return true;
        }

        public bool validateKeyType(string keyType, string keyId)
        {
            switch (keyType.ToUpper())
            {
                case ValidationEnums.KEY_TYPE_IDENT:
                    if (!validateRegex(keyId, ValidationEnums.KEY_ID_IDENT))
                    {
                        throw new SerfiException(ResponseServiceEnums.INVALID_KEY_ID.getErrorCode(), ResponseServiceEnums.INVALID_KEY_ID.getMessage(), ResponseServiceEnums.INVALID_KEY_ID.getHttpCode());
                    }
                    else
                    {
                        return true;
                    }
                case ValidationEnums.KEY_TYPE_CEL:
                    if (!validateRegex(keyId, ValidationEnums.KEY_ID_CEL))
                    {
                        throw new SerfiException(ResponseServiceEnums.INVALID_KEY_ID.getErrorCode(), ResponseServiceEnums.INVALID_KEY_ID.getMessage(), ResponseServiceEnums.INVALID_KEY_ID.getHttpCode());
                    }
                    else
                    {
                        return true;
                    }
                case ValidationEnums.KEY_TYPE_EMAIL:
                    if (!validateRegex(keyId, ValidationEnums.KEY_ID_EMAIL))
                    {
                        throw new SerfiException(ResponseServiceEnums.INVALID_KEY_ID.getErrorCode(), ResponseServiceEnums.INVALID_KEY_ID.getMessage(), ResponseServiceEnums.INVALID_KEY_ID.getHttpCode());
                    }
                    else
                    {
                        return true;
                    }
                case ValidationEnums.KEY_TYPE_ALIAS:
                    if (!validateRegex(keyId, ValidationEnums.KEY_ID_ALIAS))
                    {
                        throw new SerfiException(ResponseServiceEnums.INVALID_KEY_ID.getErrorCode(), ResponseServiceEnums.INVALID_KEY_ID.getMessage(), ResponseServiceEnums.INVALID_KEY_ID.getHttpCode());
                    }
                    else
                    {
                        return true;
                    }
                case ValidationEnums.KEY_TYPE_MERCH:
                    if (!validateRegex(keyId, ValidationEnums.KEY_ID_MERCH))
                    {
                        throw new SerfiException(ResponseServiceEnums.INVALID_KEY_ID.getErrorCode(), ResponseServiceEnums.INVALID_KEY_ID.getMessage(), ResponseServiceEnums.INVALID_KEY_ID.getHttpCode());
                    }
                    else
                    {
                        return true;
                    }
                default:
                    return false;
            }
        }
        public bool IsValidCountryCode(string countryCode)
        {
            var countryProvider = new CountryProvider();
            var country = countryProvider.GetCountry(countryCode.ToUpper());
            return country != null;
        }

        public bool validateTypeEnterprise(string enterpriseType)
        {
            switch (enterpriseType.ToUpper())
            {
                case ValidationEnums.PERSON:
                    return true;
                    break;
                case ValidationEnums.COMMERCE:
                    return true;
                    break;
                default:
                    return false;
                    break;
            }
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

        public bool validateDateFormat(string dateString)
        {
            return DateTime.TryParseExact(
                dateString,
                ValidationEnums.DATE_HEADER_FORMAT,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out _);
        }

    }
}
