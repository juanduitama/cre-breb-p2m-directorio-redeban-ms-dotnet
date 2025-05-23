using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPI_Update_Enterprise_Service.Domain.constants
{
    /// <summary>
    /// ConstantsEnum define los valores de constantes utilizadas
    /// 
    /// Desarrollo 
    /// 
    /// Requerimiento:
    /// </summary>
    /// 

    public enum ConstantsEnums
    {
        APPLICATION_JSON,
        APPLICATION_URL_ENCODE,
        TYPE_PERSON,
        ORIGIN,
        TYPE_COMMERCE,
        OAUTH_TOKEN,
        BEARER,
        IP_ORIGIN,
        RBM_FROM,
        IBM_CLIENT_ID,
        IBM_CLIENT_SECRET,
        CERTIFICATE,
        SCOPES,
        GRANTYPE,
        BASE_URI_UPDATE_ENTERPRISE,
        BASE_URI_OAUTH,
        BUCKET_NAME,
        PATHS3,
        PSW_CERTIFICATE,
    }
    public static class ConstantsEnumsExtensions
    {

        public static string getValue(this ConstantsEnums constantsEnums) {

            return constantsEnums switch {

                ConstantsEnums.APPLICATION_JSON => "application/json",
                ConstantsEnums.APPLICATION_URL_ENCODE => "application/x-www-form-urlencoded",
                ConstantsEnums.TYPE_PERSON => "PERSON",
                ConstantsEnums.ORIGIN => "origin",
                ConstantsEnums.TYPE_COMMERCE => "COMMERCE",
                ConstantsEnums.OAUTH_TOKEN => "TOKEN",
                ConstantsEnums.BEARER => "Bearer",
                ConstantsEnums.IP_ORIGIN => "10.415.16.2",
                ConstantsEnums.RBM_FROM => "d0573cdf-112f-4bda-ab35-d25363cf4092",
                ConstantsEnums.SCOPES => "HUB",
                ConstantsEnums.GRANTYPE => "client_credentials",
                ConstantsEnums.CERTIFICATE => "CERTIFICATE",
                //ConstantsEnums.IBM_CLIENT_ID => "IBM_CLIENT_ID",
                //ConstantsEnums.IBM_CLIENT_SECRET => "IBM_CLIENT_SECRET",
                //ConstantsEnums.BASE_URI_CANCELLATION => "BASE_URI_CANCELLATION",
                //ConstantsEnums.BASE_URI_OAUTH => "BASE_URI_OAUTH",
                ConstantsEnums.IBM_CLIENT_ID => "54cfb091cdd1c1f30f9cb3423a28aebe",
                ConstantsEnums.IBM_CLIENT_SECRET => "c92296aaeeb1965330c077e1a8f73889",
                ConstantsEnums.BASE_URI_UPDATE_ENTERPRISE => "https://api-qa.rbm.com.co:5444/rbmcalidad/calidad/api/kyc/v3.0.0/enterprise/Commerce/{MerchantID}",
                ConstantsEnums.BASE_URI_OAUTH => "https://gateway.qa.sandboxhubredeban.com/rbmcalidad/calidad/oauth2.0/oauth2/token",
                ConstantsEnums.BUCKET_NAME => "BUCKET_NAME",
                ConstantsEnums.PATHS3 => "PATHS3",
                ConstantsEnums.PSW_CERTIFICATE => "PASSWORD_CERTIFICATE",
                _ => throw new ArgumentOutOfRangeException(nameof(constantsEnums))
            };

        }
        

    }
}
