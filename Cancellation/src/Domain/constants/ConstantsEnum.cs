using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPI_Cancellation_Service.Domain.constants
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
        //IBM_CLIENT_ID = "IBM_CLIENT_ID";
        //IBM_CLIENTSECRET = "IBM_CLIENTSECRET";
        IBM_CLIENT_ID,
        IBM_CLIENTSECRET,
        CERTIFICATE,
        SCOPES,
        GRANTYPE,
        BASE_URI,
        DELETE_URI,
        BASE_URI_OAUTH,
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
                //ConstantsEnums.IBM_CLIENT_ID => "IBM_CLIENT_ID",
                //ConstantsEnums.IBM_Client_Secret => "IBM_CLIENTSECRET",
                ConstantsEnums.IBM_CLIENT_ID => "54cfb091cdd1c1f30f9cb3423a28aebe",
                ConstantsEnums.IBM_CLIENTSECRET => "c92296aaeeb1965330c077e1a8f73889",
                ConstantsEnums.CERTIFICATE => "CERTIFICATE",
                ConstantsEnums.SCOPES => "HUB",
                ConstantsEnums.GRANTYPE => "client_credentials",
                ConstantsEnums.BASE_URI => "https://gateway.qa.sandboxhubredeban.com/rbmcalidad/calidad/api/dir/v3.0.0/Directory/",
                ConstantsEnums.DELETE_URI => "keytype/{keyType}/key/{keyValue}",
                ConstantsEnums.BASE_URI_OAUTH => "https://gateway.qa.sandboxhubredeban.com/rbmcalidad/calidad/oauth2.0/oauth2/token",
                _ => throw new ArgumentOutOfRangeException(nameof(constantsEnums))
            };

        }
        

    }
}
